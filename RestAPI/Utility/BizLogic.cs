using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Utility
{
    public class BizLogic
    {
        ssisdbContext db;
        UserManager<EmployeeModel> _userManager;
        public BizLogic()
        {
            db = new ssisdbContext();
            _userManager = new UserManager<EmployeeModel>(new UserStore<EmployeeModel>(db));
        }
        /*ZAR AUNG PHYO */
        public List<ItemViewModel> generateOrders()
        {
            try
            {
                //db.Configuration.ProxyCreationEnabled = false;
                List<ItemViewModel> items = db.Items.AsEnumerable().Where(s => s.QuantityOnHand <= s.ReorderLevel
                && s.Status == Convert.ToString((int)InventoryStatus.UnAvailable)
                && s.Status != Convert.ToString((int)InventoryStatus.Ordered)
                ).Select(x => new ItemViewModel
                {
                    ItemId = x.ItemId,
                    ItemDescription = x.ItemDescription,
                    UnitId = x.UnitId,
                    MeasurementUnit = db.MeasurementUnits.Where(s => s.UnitId == x.UnitId).Select(e => new MeasurementUnitViewModel { UnitId = e.UnitId, UnitName = e.UnitName }).FirstOrDefault(),
                    QuantityOnHand = x.QuantityOnHand,
                    ReorderLevel = x.ReorderLevel,
                    ReorderQuantity = x.ReorderQuantity,
                    CategoryId = x.CategoryId,
                    LocationId = x.LocationId,
                    Remark = x.Remark,
                    Status = x.Status
                }).ToList();
                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Supplier> getSupplier()
        {
            try
            {
                //db.Configuration.ProxyCreationEnabled = false;
                List<Supplier> suppliers = db.Suppliers.Where(s => s.Status == "1").ToList();
                return suppliers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool purchaseOrder(List<ItemViewModel> items, string empid)
        {
            try
            {
                PurchaseOrder po = new PurchaseOrder();
                po.EmployeeId = empid;
                po.PurchaseOrderDate = DateTime.Now.Date;
                po.Status = Convert.ToString((int)PurchaseOrderStatus.Open); //"1";
                foreach (ItemViewModel item in items)
                {
                    SupplierItem si = db.SupplierItems.Where(s => s.SupplierId == item.supplierId && s.ItemId == item.ItemId).FirstOrDefault();
                    if (si == null)
                    {
                        throw new Exception(string.Format("{0} are not supplied by this {1} . Please make sure Item Suppliers", item.ItemDescription, db.Suppliers.Where(x => x.SupplierId == item.supplierId).FirstOrDefault().SupplierName));
                    }
                    PurchaseOrderDetail pod = new PurchaseOrderDetail();
                    pod.PurchaseItemQuantity = item.ReorderQuantity;
                    pod.SupplierItemId = si.SupplierItemId;
                    pod.Status = Convert.ToString((int)PurchaseOrderDetailStatus.Pending);
                    po.PurchaseOrderDetails.Add(pod);

                    // si.Item.Status = (Convert.ToString((int)InventoryStatus.Ordered));
                    db.Items.Where(x => x.ItemId == si.ItemId).FirstOrDefault().Status = (Convert.ToString((int)InventoryStatus.Ordered));
                }

                db.PurchaseOrders.Add(po);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<PurchaseOrderViewModel> GetPurchaseOrders()
        {
            try
            {
                string deliver = Convert.ToString((int)PurchaseOrderDetailStatus.Delivered);
                string cancel = Convert.ToString((int)PurchaseOrderDetailStatus.Cancelled);
                string open = Convert.ToString((int)PurchaseOrderStatus.Open);
                IList<PurchaseOrderViewModel> poLst = (from i in db.Items
                                                       join si in db.SupplierItems on i.ItemId equals si.ItemId
                                                       join pod in db.PurchaseOrderDetails on si.SupplierItemId equals pod.SupplierItemId
                                                       join po in db.PurchaseOrders on pod.PurchaseOrderId equals po.PurchaseOrderId
                                                       into all
                                                       from x in all
                                                       where x.Status == open //&& x.PurchaseOrderDetails.Where(e=>e.Status != deliver && e.Status != cancel).ToList()
                                                       select new PurchaseOrderViewModel
                                                       {
                                                           PurchaseOrderId = x.PurchaseOrderId,
                                                           EmployeeId = x.EmployeeId,
                                                           Status = x.Status,
                                                           PurchaseOrderDate = x.PurchaseOrderDate,
                                                           Remark = x.Remark,
                                                           ExpectedDate = x.ExpectedDate,
                                                           PurchaseOrderDetails = x.PurchaseOrderDetails
                                                           .Where(p => p.Status != deliver
                                                           && p.Status != cancel)
                                                           .Select(s => new PurchaseOrderDetailViewModel
                                                           {
                                                               PurchaseOrderDetailsId = s.PurchaseOrderDetailsId,
                                                               PurchaseOrderId = s.PurchaseOrderId,
                                                               PurchaseItemQuantity = s.PurchaseItemQuantity,
                                                               QuantityDelivered = s.QuantityDelivered ?? 0,
                                                               Status = s.Status,
                                                               Remark = s.Remark,
                                                               SupplierItemId = s.SupplierItemId,
                                                               SupplierItem = new SupplierItemViewModel
                                                               {
                                                                   SupplierItemId = s.SupplierItemId,
                                                                   Item = new ItemViewModel
                                                                   {
                                                                       ItemId = s.SupplierItem.Item.ItemId,
                                                                       ItemDescription = s.SupplierItem.Item.ItemDescription,
                                                                       QuantityOnHand = s.SupplierItem.Item.QuantityOnHand,
                                                                       ReorderLevel = s.SupplierItem.Item.ReorderLevel,
                                                                       ReorderQuantity = s.SupplierItem.Item.ReorderQuantity
                                                                   }
                                                               }
                                                           }).ToList()
                                                       }).AsEnumerable().GroupBy(g => g.PurchaseOrderId).Select(group => group.First()).ToList();

                return poLst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //as long as store clerk not confirm the purchase order, item inventory will not be effected
        public bool closedPurchaseOrder(List<PurchaseOrderViewModel> vm)
        {
            try
            {
                foreach (var po in vm)
                {
                    foreach (PurchaseOrderDetailViewModel podvm in po.PurchaseOrderDetails)
                    {
                        PurchaseOrderDetail pod = db.PurchaseOrderDetails.Where(s => s.PurchaseOrderDetailsId == podvm.PurchaseOrderDetailsId && s.PurchaseOrderId == po.PurchaseOrderId).FirstOrDefault();
                        Item item = db.SupplierItems.Where(x => x.SupplierItemId == pod.SupplierItemId).Select(s => s.Item).FirstOrDefault();
                        item.QuantityOnHand = item.QuantityOnHand + podvm.QuantityDelivered;
                        if (item.QuantityOnHand <= 0)
                        {
                            item.Status = Convert.ToString((int)InventoryStatus.UnAvailable);
                        }
                        else
                        {
                            item.Status = Convert.ToString((int)InventoryStatus.Available);
                        }
                        pod.Status = Convert.ToString((int)PurchaseOrderDetailStatus.Delivered);
                        db.SaveChanges();
                    }
                    //closed po
                    db.PurchaseOrders.Where(s => s.PurchaseOrderId == po.PurchaseOrderId).FirstOrDefault().Status = Convert.ToString((int)PurchaseOrderStatus.Closed);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //as long as store clerk not confirm the purchase order, item inventory will not be effected
        //item inventory will not be effected, only change pod status to 'confirmed'
        public bool updatePurchaseOrderDetail(PurchaseOrderViewModel vm)
        {
            try
            {
                int podid = vm.PurchaseOrderDetails.FirstOrDefault().PurchaseOrderDetailsId;
                PurchaseOrderDetail pod = db.PurchaseOrderDetails.Where(s => s.PurchaseOrderDetailsId == podid)
                    .FirstOrDefault();
                // Item item = db.SupplierItems.Where(x => x.SupplierItemId == pod.SupplierItemId).Select(s => s.Item).FirstOrDefault();
                //  item.QuantityOnHand = item.QuantityOnHand + vm.PurchaseOrderDetails.FirstOrDefault().QuantityDelivered;
                pod.QuantityDelivered = Convert.ToInt32(vm.PurchaseOrderDetails.FirstOrDefault().QuantityDelivered);
                pod.Status = Convert.ToString((int)PurchaseOrderDetailStatus.Confirmed);

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool removePurchaseOrderDetail(PurchaseOrderViewModel vm)
        {
            try
            {
                int podid = vm.PurchaseOrderDetails.FirstOrDefault().PurchaseOrderDetailsId;
                PurchaseOrderDetail pod = db.PurchaseOrderDetails.Where(s => s.PurchaseOrderDetailsId == podid)
                    .FirstOrDefault();
                pod.Status = Convert.ToString((int)PurchaseOrderDetailStatus.Cancelled);

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<StationeryRetrievalView> getRetrievalList()
        {
            string available = Convert.ToString((int)InventoryStatus.Available);
            int opened = (int)RequisitionStatus.Opened;
            string approved = Convert.ToString((int)RequisitionDetailStatus.Approved);
            string Fullfill = Convert.ToString((int)RequisitionDetailStatus.Fullfill);
            string unFulfill = Convert.ToString((int)RequisitionDetailStatus.Unfulfill);

            IList<StationeryRetrievalView> retrieval = (from ir in db.ItemRequisitions
                                                        join ird in db.ItemRequisitionDetails on ir.RequisitionId equals ird.RequisitionId
                                                        join emp in db.AspNetUsers on ir.EmployeeId equals emp.Id
                                                        join dept in db.Departments on emp.DepartmentId equals dept.DepartmentId
                                                        join i in db.Items on ird.ItemId equals i.ItemId
                                                        where ir.FormStatus == opened && ird.ApproveStatus == approved && ird.ReceiveStatus != Fullfill
                                                        && i.QuantityOnHand > 0
                                                        //&& i.Status == available
                                                        select new StationeryRetrievalView
                                                        {
                                                            RequisitionDetailsId = ird.RequisitionDetailsId,
                                                            NeededQuantity = ird.NeededQuantity,
                                                            ActualQuantity = ird.ActualQuantity,
                                                            ItemId = i.ItemId,
                                                            ItemDescription = i.ItemDescription,
                                                            DepartmentId = dept.DepartmentId,
                                                            DepartmentName = dept.DepartmentName,
                                                            QuantityOnHand = i.QuantityOnHand,
                                                            ReceivedStatus = ird.ReceiveStatus,
                                                            ItemLocation = i.ItemLocation.LocationDesc
                                                        }).ToList();
            string ackStatus = Convert.ToString((int)DisbursementAckStatus.Unackowledge);
            List<Disbursement> carryOutstandingAmt = db.Disbursements.Where(x => x.NeededQuantity - x.ActualQuantity > 0 && x.ACKStatus == ackStatus).ToList();
            foreach (var item in carryOutstandingAmt)
            {
                foreach (var ret in retrieval.Where(s => s.RequisitionDetailsId == item.Status && s.ReceivedStatus == unFulfill).ToList())
                {
                    ret.NeededQuantity = ((int)item.NeededQuantity - (int)item.ActualQuantity);
                }
            }
            return retrieval;
        }
        public EmployeeViewModel getCurrentUser(string id)
        {
            try
            {
                EmployeeViewModel evm = db.AspNetUsers.Where(s => s.Id == id).Select(s => new EmployeeViewModel
                {
                    EmployeeId = s.Id,
                    EmployeeName = s.EmployeeName,
                    DepartmentId = s.DepartmentId,
                    UserName = s.UserName,
                    Email = s.Email,
                    DelegationStatus = s.DelegationStatus,
                    //   Roles = s.Roles.Where()
                    Roles = db.Roles.Where(x => s.Roles.Select(e => e.RoleId).Contains(x.Id)).Select(r => new EmployeeRoleViewModel
                    {
                        RoleId = r.Id,
                        RoleName = r.Name
                    }).ToList()
                }).FirstOrDefault();
                return evm;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void updateRetrievalt(IList<StationeryRetrievalView> vm)
        {
            try
            {
                IList<Disbursement> disbursements = new List<Disbursement>();
                //calc Qty on hand
                IList<StationeryRetrievalView> groupItemById = vm.GroupBy(x => new { ItemId = x.ItemId },
                             (key, values) => new StationeryRetrievalView
                             {
                                 ItemId = key.ItemId,
                                 QuantityOnHand = values.First().QuantityOnHand - values.Sum(x => x.ActualQuantity)
                             }).ToList();

                foreach (StationeryRetrievalView stationery in vm.Where(x => x.ActualQuantity > 0).ToList())
                {
                    var breakdownBIndividual = vm.Where(x => x.ItemId == stationery.ItemId && x.DepartmentId == stationery.DepartmentId).ToList();
                    var gropbyItem = db.ItemRequisitionDetails.AsEnumerable().Where(x => breakdownBIndividual.Select(v => v.RequisitionDetailsId.ToString()).ToList().Contains(x.RequisitionDetailsId.ToString()))
                        .Select(e => new { e.RequisitionDetailsId, e.NeededQuantity }).ToList();

                    var calcIndvAtualQty = (gropbyItem.Where(x => x.RequisitionDetailsId == stationery.RequisitionDetailsId)
                        .Select(t => (double)t.NeededQuantity).First() / gropbyItem.Select(t => (double)t.NeededQuantity).Sum())
                        * (double)breakdownBIndividual.First().ActualQuantity;

                    var isExistingDis = db.Disbursements.Where(x => x.Status == stationery.RequisitionDetailsId).FirstOrDefault();

                    if (isExistingDis == null)
                    {
                        disbursements.Add(new Disbursement
                        {
                            ItemId = stationery.ItemId,
                            DepartmentId = stationery.DepartmentId,
                            ActualQuantity = (int)calcIndvAtualQty,
                            NeededQuantity = db.ItemRequisitionDetails.Where(x => x.RequisitionDetailsId == stationery.RequisitionDetailsId).FirstOrDefault().NeededQuantity,
                            RetrievalDate = DateTime.Now.Date,
                            ACKStatus = Convert.ToString((int)DisbursementAckStatus.Unackowledge),
                            Status = stationery.RequisitionDetailsId
                        });
                    }
                    else
                    {
                        var d = db.Disbursements.Where(x => x.Status == stationery.RequisitionDetailsId).FirstOrDefault();
                        d.NeededQuantity = d.NeededQuantity - d.ActualQuantity;
                        d.ActualQuantity = (int)calcIndvAtualQty;
                    }
                }

                db.Disbursements.AddRange(disbursements);
                db.SaveChanges();

                foreach (StationeryRetrievalView s in vm)
                {
                    //breakdown by individual requested qty
                    var breakdownBIndividual = vm.Where(x => x.ItemId == s.ItemId && x.DepartmentId == s.DepartmentId).ToList();

                    var gropbyItem = db.ItemRequisitionDetails.AsEnumerable().Where(x => breakdownBIndividual.Select(v => v.RequisitionDetailsId.ToString()).ToList().Contains(x.RequisitionDetailsId.ToString()))
                        .Select(e => new { e.RequisitionDetailsId, e.NeededQuantity }).ToList();

                    var calcIndvAtualQty = (gropbyItem.Where(x => x.RequisitionDetailsId == s.RequisitionDetailsId)
                        .Select(t => (double)t.NeededQuantity).First() / gropbyItem.Select(t => (double)t.NeededQuantity).Sum())
                        * (double)breakdownBIndividual.First().ActualQuantity;

                    var ird = db.ItemRequisitionDetails.Where(x => x.RequisitionDetailsId == s.RequisitionDetailsId).FirstOrDefault();
                    ird.ActualQuantity += Convert.ToInt32(calcIndvAtualQty);
                    if (ird.ActualQuantity == ird.NeededQuantity)
                    {
                        ird.ReceiveStatus = (Convert.ToString((int)RequisitionDetailStatus.Fullfill));
                    }
                    else
                    {
                        ird.ReceiveStatus = (Convert.ToString((int)RequisitionDetailStatus.Unfulfill));
                    }
                    db.SaveChanges();
                }
                //List<StationeryRetrievalView> saveToDis = vm.GroupBy(g => new { ItemId = g.ItemId, DepartmentId = g.DepartmentId }, (key, values) => new StationeryRetrievalView
                //{
                //    ItemId = key.ItemId,
                //    DepartmentId = key.DepartmentId,
                //    NeededQuantity = values.First().NeededQuantity,
                //    ActualQuantity = values.First().ActualQuantity
                //}).Where(x=>x.ActualQuantity > 0).ToList();


                foreach (StationeryRetrievalView qty in groupItemById)
                {
                    var checkInv = db.Items.Where(s => s.ItemId == qty.ItemId).FirstOrDefault();
                    checkInv.QuantityOnHand = qty.QuantityOnHand;
                    if (checkInv.QuantityOnHand <= 0)
                    {
                        checkInv.Status = Convert.ToString((int)InventoryStatus.UnAvailable);
                    }
                    else
                    {
                        checkInv.Status = Convert.ToString((int)InventoryStatus.Available);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<DisbursementViewModel> GetDisbursements()
        {
            try
            {
                //  //db.Configuration.ProxyCreationEnabled = false;
                IList<DisbursementViewModel> lst = db.Disbursements.AsEnumerable().Where(x => x.ACKStatus == Convert.ToString((int)DisbursementAckStatus.Unackowledge)).Select(s => new DisbursementViewModel
                {
                    DisbursementId = s.DisbursementId,
                    ItemId = s.ItemId,
                    ItemDescription = db.Items.Where(x => x.ItemId == s.ItemId).Select(c => c.ItemDescription).FirstOrDefault(),
                    DepartmentId = s.DepartmentId,
                    DepartmentName = db.Departments.Where(x => x.DepartmentId == s.DepartmentId).Select(c => c.DepartmentName).FirstOrDefault(),
                    NeededQuantity = s.NeededQuantity,
                    ActualQuantity = s.ActualQuantity,
                    ReturnQuantity = s.ReturnQuantity,
                    QuantityOnHand = db.Items.Where(x => x.ItemId == s.ItemId).Select(c => c.QuantityOnHand).FirstOrDefault(),
                    OutstandingAmount = (int)s.NeededQuantity - (int)s.ActualQuantity,
                    ACKStatus = s.ACKStatus,
                    CollectDate = s.CollectDate,
                    Reason = s.Reason,
                    RetrievalDate = s.RetrievalDate,
                    Status = s.Status,
                    Remark = s.Remark,
                    QRCode = s.QRCode
                }).ToList();

                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void updateDisbursement(Disbursement vm)
        {
            try
            {
                Disbursement d = db.Disbursements.First(s => s.DisbursementId == vm.DisbursementId);
                Item item = db.Items.First(s => s.ItemId == vm.ItemId);
                if (d.ActualQuantity > vm.ActualQuantity)
                {
                    item.QuantityOnHand = item.QuantityOnHand + ((int)d.ActualQuantity - (int)vm.ActualQuantity);
                }
                else
                {
                    item.QuantityOnHand = item.QuantityOnHand - ((int)vm.ActualQuantity - (int)d.ActualQuantity);
                }
                d.ActualQuantity = vm.ActualQuantity;
                //  db.Disbursements.First(s => s.DisbursementId == vm.DisbursementId).ActualQuantity = vm.ActualQuantity;
                //  item.QuantityOnHand = item.QuantityOnHand - (int) vm.ActualQuantity;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool addSpoiledItem(ItemAdjustmentViewModel adj, string empid)
        {
            try
            {
                int adjQty = adj.AdjustmentQuantity;
                string unsubmitted = Convert.ToString((int)ItemAdjustmentStatus.Unsubmitted);
                var isExisted = db.ItemAdjustments.Where(x => x.ItemId == adj.ItemId && x.Status == unsubmitted).FirstOrDefault();
                if (isExisted != null)
                {
                    var c = db.Items.Where(s => s.ItemId == adj.ItemId).FirstOrDefault();
                    c.QuantityOnHand += adjQty;
                    isExisted.AdjustmentQuantity += adjQty;
                }
                else
                {
                    adj.EmployeeId = empid;
                    adj.Status = unsubmitted;
                    db.ItemAdjustments.Add(new ItemAdjustment
                    {
                        ItemId = adj.ItemId,
                        AdjustmentQuantity = adj.AdjustmentQuantity,
                        ItemAdjustmentDate = DateTime.Now.Date,
                        Reason = adj.Reason,
                        EmployeeId = empid,
                        Status = adj.Status,
                        Remark = adj.Remark
                    });

                    db.Items.Where(s => s.ItemId == adj.ItemId).FirstOrDefault().QuantityOnHand += adjQty;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool updateSpoiledItem(ItemAdjustmentViewModel adj, string empid)
        {
            try
            {
                db.ItemAdjustments.Where(x => x.ItemAdjustmentId == adj.ItemAdjustmentId).FirstOrDefault()
                    .AdjustmentQuantity = adj.AdjustmentQuantity;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool removeSpoiledItem(int ItemAdjustmentId)
        {
            try
            {
                var remove = db.ItemAdjustments.Where(x => x.ItemAdjustmentId == ItemAdjustmentId).FirstOrDefault();
                db.ItemAdjustments.Remove(remove);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool addAdjustedItems(List<ItemAdjustment> adjs)
        {
            try
            {
                foreach (ItemAdjustment adj in adjs)
                {
                    db.ItemAdjustments.Where(s => s.ItemAdjustmentId == adj.ItemAdjustmentId).FirstOrDefault().Status = Convert.ToString((int)ItemAdjustmentStatus.Submitted);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<ItemAdjustmentViewModel> getAdjItems()
        {
            try
            {
                IList<ItemAdjustmentViewModel> adjs = db.ItemAdjustments.AsEnumerable().Where(s => s.Status == Convert.ToString((int)ItemAdjustmentStatus.Unsubmitted))
                    .Select(s => new ItemAdjustmentViewModel
                    {
                        ItemAdjustmentId = s.ItemAdjustmentId,
                        ItemId = s.ItemId,
                        Reason = s.Reason,
                        Remark = s.Remark,
                        AdjustmentQuantity = s.AdjustmentQuantity,
                        ItemAdjustmentDate = s.ItemAdjustmentDate,
                        Item = db.Items.Where(x => x.ItemId == s.ItemId).Select(e => new ItemViewModel
                        {
                            ItemId = e.ItemId,
                            ItemDescription = e.ItemDescription,
                            QuantityOnHand = e.QuantityOnHand
                        ,
                            MeasurementUnit = db.MeasurementUnits.Where(h => h.UnitId == e.UnitId).Select(j => new MeasurementUnitViewModel { UnitId = j.UnitId, UnitName = j.UnitName }).FirstOrDefault(),
                        }).FirstOrDefault()
                    }).ToList();

                return adjs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<Department> GetDepartments()
        {
            try
            {
                //db.Configuration.ProxyCreationEnabled = false;
                return db.Departments.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<MeasurementUnit> getUnits()
        {
            try
            {
                //db.Configuration.ProxyCreationEnabled = false;
                List<MeasurementUnit> units = db.MeasurementUnits.ToList();
                return units;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Item> getItems()
        {
            try
            {
                //db.Configuration.ProxyCreationEnabled = false;
                List<Item> items = db.Items.Where(s => s.QuantityOnHand > s.ReorderLevel).ToList();
                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ItemRequisitionsViewModel> GetAllRequisition()
        {
            try
            {
                //db.Configuration.ProxyCreationEnabled = false;
                //db.Configuration.LazyLoadingEnabled = false;
                List<ItemRequisitionsViewModel> lst = db.ItemRequisitions.Select(s => new ItemRequisitionsViewModel
                {
                    RequisitionId = s.RequisitionId,
                    EmployeeId = s.EmployeeId,
                    EmployeeName = db.AspNetUsers.Where(x => x.Id == s.EmployeeId).Select(c => c.EmployeeName).FirstOrDefault(),
                    RequisitionDate = s.RequisitionDate,
                    FormStatus = s.FormStatus,
                    Status = s.Status,
                    ReceiveDate = s.ReceiveDate,
                    Remark = s.Remark,
                    ApproveDate = s.ApproveDate,
                    ApproveStatus = s.ApproveStatus
                }).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //public List<ItemRequisitionDetail> GetItemRequisitionDetailByreqId(int reqId, String ApproveStatus)
        //{
        //    try
        //    {
        //        // //db.Configuration.ProxyCreationEnabled = false;
        //        List<ItemRequisitionDetail> list = db.ItemRequisitionDetails.Where(x => x.RequisitionId == reqId & x.ApproveStatus == ApproveStatus).ToList();
        //        return list;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        /*SOE YADANA KO HTET*/
        public int CreateItemRequistion(ItemRequisition item)
        {
            try
            {
                item.FormStatus = (int)RequisitionStatus.Pending;
                db.ItemRequisitions.Add(item);
                db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ItemRequisition> GetEmpItemRequistion(string empId)
        {
            //db.Configuration.ProxyCreationEnabled = false;
            return db.ItemRequisitions.Where(x => x.EmployeeId == empId).ToList();
        }

        public List<ItemRequisitionDetail> GetEmpItemRequistionDetail(int reqId)
        {
            //db.Configuration.ProxyCreationEnabled = false;
            return db.ItemRequisitionDetails.Where(x => x.RequisitionId == reqId).ToList();
        }

        public List<ItemRequisition> GetEmpItemRequistionLast(string empId)
        {
            //db.Configuration.ProxyCreationEnabled = false;
            return db.ItemRequisitions.Where(x => x.EmployeeId == empId).ToList();
        }

        public List<ItemRequisitionsViewModel> GetAllEmpItemRequistion(string id)
        {
            //db.Configuration.ProxyCreationEnabled = false;
            //db.Configuration.LazyLoadingEnabled = false;
            int deptid = db.AspNetUsers.Where(x => x.Id == id).Select(x => x.DepartmentId).FirstOrDefault();
            //  List<ItemRequisition> itemlist = db.ItemRequisitions.AsEnumerable().Where(x => x.FormStatus == (int)RequisitionStatus.Pending).ToList();

            //update by zap
            List<ItemRequisitionsViewModel> itemlist = (from ir in db.ItemRequisitions.AsEnumerable()
                                                        join u in db.AspNetUsers on ir.EmployeeId equals u.Id
                                                        where ir.FormStatus == (int)RequisitionStatus.Pending
                                                        && u.DepartmentId == deptid
                                                        select new ItemRequisitionsViewModel
                                                        {
                                                            RequisitionId = ir.RequisitionId,
                                                            EmployeeId = ir.EmployeeId,
                                                            RequisitionDate = ir.RequisitionDate,
                                                            ApproveStatus = ir.ApproveStatus,
                                                            FormStatus = ir.FormStatus,
                                                            Status = ir.Status,
                                                            ApproveDate = ir.ApproveDate,
                                                            ReceiveDate = ir.ReceiveDate,
                                                            Remark = ir.Remark,
                                                            Employee = new EmployeeModel
                                                            {
                                                                Id = u.Id,
                                                                EmployeeName = u.EmployeeName,
                                                                UserName = u.UserName,
                                                                DepartmentId = u.DepartmentId
                                                            }
                                                        }).ToList();
            return itemlist;
        }

        public List<ItemRequisition> getAllEmpItemRequisitionHistory()
        {
            //db.Configuration.ProxyCreationEnabled = false;
            List<ItemRequisition> itemlist = db.ItemRequisitions.Where(x => x.FormStatus != (int)RequisitionStatus.Pending).ToList();
            return itemlist;
        }

        public ItemRequisitionDetail getItemRequistionDetailbyItemId(int id, int itemId)
        {
            return db.ItemRequisitionDetails.Where(x => x.RequisitionId == id && x.ItemId == itemId).First();
        }

        public ItemRequisition getItemRequistionByreqId(int id)
        {
            return db.ItemRequisitions.Where(x => x.RequisitionId == id).First();
        }

        public int updateItemDetailStatus(ItemRequisitionDetail item)
        {
            try
            {
                ItemRequisitionDetail itemRequisitionDetail = GetItemRequisitionDetailById(item.RequisitionDetailsId);
                if (itemRequisitionDetail != null)
                {
                    itemRequisitionDetail.Remark = item.Remark;
                    itemRequisitionDetail.ApproveStatus = item.ApproveStatus;
                    db.SaveChanges();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ItemRequisitionDetail> getEmpItemRequistionDetailsById(int id)
        {
            //db.Configuration.ProxyCreationEnabled = false;
            List<ItemRequisitionDetail> itemlist = db.ItemRequisitionDetails.Where(x => x.RequisitionId == id).ToList();
            return itemlist;
        }

        public EmployeeModel getEmpbyId(string id)
        {
            return db.AspNetUsers.Where(x => x.Id == id).First();
        }

        public List<Category> GetCategories()
        {
            //db.Configuration.ProxyCreationEnabled = false;
            return db.Categories.ToList();
        }

        public List<Item> GetItemsByCategory(int categoryId)
        {
            //db.Configuration.ProxyCreationEnabled = false;
            return db.Items.AsEnumerable().Where(x => x.CategoryId == categoryId && x.Status == Convert.ToString((int)InventoryStatus.Available)).ToList();
        }

        public List<MeasurementUnit> GetMeasurementUnit()
        {
            //db.Configuration.ProxyCreationEnabled = false;
            return db.MeasurementUnits.ToList();
        }

        public int UpdateItemRequisition(ItemRequisition item)
        {
            ItemRequisition itemRequisition = getItemRequistionByreqId(item.RequisitionId);
            if (itemRequisition != null)
            {
                itemRequisition.Remark = item.Remark;
                itemRequisition.FormStatus = item.FormStatus;
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public ItemRequisitionDetail GetItemRequisitionDetailById(int Id)
        {
            return db.ItemRequisitionDetails.Where(x => x.RequisitionDetailsId == Id).First();
        }

        public List<Item> GetItems()
        {
            //db.Configuration.ProxyCreationEnabled = false;
            return db.Items.ToList();
        }



        public Category GetCategoryById(int id)
        {
            return db.Categories.Where(x => x.CategoryId == id).First();
        }


        public Item GetItemById(int id)
        {
            return db.Items.Where(x => x.ItemId == id).First();
        }

        public Department GetDeptInfo(int Id)
        {
            db.Configuration.ProxyCreationEnabled = true;
            db.Configuration.LazyLoadingEnabled = true;
            return db.Departments.Where(x => x.DepartmentId == Id).First();
        }


        public int UpdateDeptInfo(Department department)
        {
            Department dept = GetDeptInfo(department.DepartmentId);
            if (dept != null)
            {
                dept.ContactName = department.ContactName;
                dept.PhoneNo = department.PhoneNo;
                dept.FaxNo = department.FaxNo;
                dept.CollectionPointId = department.CollectionPointId;
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public int CreateItemRequistionDetails(List<ItemRequisitionDetail> item)
        {
            try
            {
                for (int i = 0; i < item.Count; i++)
                {
                    item[i].ReceiveStatus = Convert.ToString((int)RequisitionDetailStatus.NA);
                    item[i].ApproveStatus = Convert.ToString((int)RequisitionDetailStatus.Pending);
                    db.ItemRequisitionDetails.Add(item[i]);
                }
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int ReturnItemAdj(ItemAdjustment itemAdj)
        {
            try
            {
                db.ItemAdjustments.Add(itemAdj);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int UpdateCollectionPt(Department department)
        {
            Department dept = GetDeptInfo(department.DepartmentId);
            if (dept != null)
            {
                dept.CollectionPointId = department.CollectionPointId;
                db.SaveChanges();

                return 1;
            }
            return 0;
        }


        public List<Disbursement> getDeptDisbursementList(int id)
        {
            //db.Configuration.ProxyCreationEnabled = false;
            return db.Disbursements.AsEnumerable().Where(x => x.DepartmentId == id && x.ACKStatus == Convert.ToString((int)DisbursementAckStatus.Unackowledge)).ToList();
        }

        public Disbursement GetDisbursementInfo(int id)
        {
            return db.Disbursements.Where(x => x.DisbursementId == id).First();
        }
        public int ReturnItem(Disbursement disbursement)
        {
            Disbursement disb = GetDisbursementInfo(disbursement.DisbursementId);
            if (disb != null)
            {
                disb.ReturnQuantity = disbursement.ReturnQuantity;
                disb.Reason = disbursement.Reason;
                disb.ACKStatus = Convert.ToString((int)DisbursementAckStatus.Acknowledge);
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        /*HANA NORDIN*/
        //ItemDetailsViewModel
        public List<ItemViewModel> GetSearchItemDetails(string search)
        {
            var itemNames = db.Items.Where(x => x.ItemDescription.Contains(search)).Select(g => new ItemViewModel()
            {
                ItemId = g.ItemId,
                ItemDescription = g.ItemDescription,
                CategoryId = g.CategoryId,
                CategoryName = g.Category.CategoryName,
                ReorderLevel = g.ReorderLevel,
                ReorderQuantity = g.ReorderQuantity,
                QuantityOnHand = g.QuantityOnHand,
                UnitId = g.UnitId,
                UnitName = g.MeasurementUnit.UnitName,
                LocationId = g.LocationId,
                LocationDesc = g.ItemLocation.LocationDesc,
                Status = g.Status,
                Remark = g.Remark

            }).ToList();
            return itemNames;
        }

        //ItemDetailsViewModel
        public List<ItemViewModel> GetAllItemDetails()
        {
            var itemNames = db.Items.Select(g => new ItemViewModel()
            {
                ItemId = g.ItemId,
                ItemDescription = g.ItemDescription,
                CategoryId = g.CategoryId,
                CategoryName = g.Category.CategoryName,
                ReorderLevel = g.ReorderLevel,
                ReorderQuantity = g.ReorderQuantity,
                QuantityOnHand = g.QuantityOnHand,
                UnitId = g.UnitId,
                UnitName = g.MeasurementUnit.UnitName,
                LocationId = g.LocationId,
                LocationDesc = g.ItemLocation.LocationDesc,
                Status = g.Status,
                Remark = g.Remark

            }).ToList();
            return itemNames;
        }

        //DeptNameModel
        public List<DeptItemsViewModel> GetAllDeptNames()
        {
            var deptNames = db.Departments.Select(g => new DeptItemsViewModel()
            {
                DepartmentId = g.DepartmentId,
                DepartmentName = g.DepartmentName
            }).ToList();

            return deptNames;
        }

        //------------------------------------------------------------------------------------------------------------

        // Adjustments for Approval (StoreManager/StoreSupervisor)
        public List<ItemAdjustmentListViewModel> GetListForApproval()
        {
            string adjustmentSubmitted = Convert.ToString((int)ItemAdjustmentStatus.Submitted);
            string activeSupplier = Convert.ToString((int)SupplierStatus.Active);

            var result = db.ItemAdjustments.Where(c => c.Status == adjustmentSubmitted).
                GroupBy(a => a.ItemId).Select(g => new ItemAdjustmentListViewModel()
                {
                    ItemId = g.Key,
                    ItemDescription = g.FirstOrDefault().Item.ItemDescription,
                    Amount = g.Sum(b => b.AdjustmentQuantity),
                    UnitName = g.FirstOrDefault().Item.MeasurementUnit.UnitName,
                    AveragePrice = db.SupplierItems.Where(x => x.ItemId == g.FirstOrDefault().ItemId &&
                   x.Supplier.Status == activeSupplier).Select(a => a.TenderPrice).DefaultIfEmpty().Average(),
                    AdjustmentValue = ((db.SupplierItems.Where(x => x.ItemId == g.FirstOrDefault().ItemId &&
                    x.Supplier.Status == activeSupplier).Select(a => a.TenderPrice).DefaultIfEmpty().Average()) *
                            Math.Abs(g.Sum(b => b.AdjustmentQuantity))),
                    Remark = ""
                }).ToList();

            // if item adjustment value is POSITIVE, Adjustment Value should be negative because money is GAINED not LOST
            foreach (var item in result)
            {
                if (item.Amount > 0)
                {
                    item.AdjustmentValue = item.AdjustmentValue * -1;
                }
            }
            foreach (var item in result)
            {
                item.Amount = Math.Abs(item.Amount);
            }
            if (result.Count > 0)
                return result;
            else
                return null;
        }
        //AdjustmentDetails Page will list the individual adjustment submissions for that particular item 
        // ItemAdjustmentDetailsViewModel
        public List<ItemAdjustmentViewModel> GetAdjustmentDetails(int id)
        {
            //db.Configuration.ProxyCreationEnabled = false;

            string adjustmentSubmitted = Convert.ToString((int)ItemAdjustmentStatus.Submitted);

            var result = db.ItemAdjustments.Where(c => c.ItemId == id && c.Status == adjustmentSubmitted).
                Select(g => new ItemAdjustmentViewModel()
                {
                    ItemId = g.ItemId,
                    ItemDescription = g.Item.ItemDescription,
                    AdjustmentQuantity = g.AdjustmentQuantity,
                    ItemAdjustmentDate = g.ItemAdjustmentDate,
                    Reason = g.Reason
                }).ToList();

            return result;
        }

        //List of Items for Approval will be approved, remark saved into database if any
        public List<ItemAdjustment> ApproveItems(string newRemark)
        {
            string adjustmentSubmitted = Convert.ToString((int)ItemAdjustmentStatus.Submitted);
            string adjustmentApproved = Convert.ToString((int)ItemAdjustmentStatus.Approved);

            List<ItemAdjustment> result = db.ItemAdjustments.Where
                (c => c.Status == adjustmentSubmitted).ToList();

            foreach (var item in result)
            {
                item.ItemAdjustmentDate = DateTime.Now;
                item.Status = adjustmentApproved;
                item.Remark = newRemark;
            }
            db.SaveChanges();
            return null;
        }

        //---------------------------------------------------------------------------------
        //Generate Charge-Back Report
        public List<DeptExpenditureViewModel> GenerateChargeBackRpt()
        {
            // checking for dates that fall between this financial year:
            DateTime lastYearApril = new DateTime(DateTime.Now.Year - 1, 4, 1);
            DateTime thisYearApril = new DateTime(DateTime.Now.Year, 4, 1);

            //NOTE: DateTime.Now.Month check is to make sure that if the current month is > April, the records retrieved
            //will be from 01-April this year, and if the current Month < April, the recorsd retrieved will be from
            //01 April this year

            // Get the total amount of each Item Disbursed to each department
            var firstSet = db.Disbursements.Where(b => DateTime.Now.Month < 4 && b.RetrievalDate > lastYearApril
            || (DateTime.Now.Month >= 4 && b.RetrievalDate >= thisYearApril)).
            GroupBy(a => new { a.ItemId, a.DepartmentId }).Select(g => new DeptItemsViewModel()
            {
                ItemId = g.Key.ItemId,
                DepartmentName = db.Departments.Where(x => x.DepartmentId == g.Key.DepartmentId).Select(y => y.DepartmentName).FirstOrDefault().ToString(),
                DeptItemTotal = (int)g.Sum(b => b.ActualQuantity)
            }).ToList();

            //The next part, secondSet, gets the average price of each item pased on the Purchase Orders which have been 
            //DELIVERED between the financial year of 01-April of the year before to 31-March of the current year
            //to make sure that departments are charge fairly per item based on the TENDERPRICE for the current
            //FInancial Year, for each supplier that has supplied those items

            // checking purchase order status:
            string purchaseOrderDelivered = Convert.ToString((int)PurchaseOrderDetailStatus.Delivered);
            var checkStatus = db.PurchaseOrderDetails.Where(b => b.Status == purchaseOrderDelivered);

            // checking purchaseOrderDate:
            var checkDate = checkStatus.Where
                (b => (DateTime.Now.Month < 4 && b.PurchaseOrder.PurchaseOrderDate >= lastYearApril)
                || (DateTime.Now.Month >= 4 && b.PurchaseOrder.PurchaseOrderDate >= thisYearApril));

            // Get average price for each item:
            var secondSet = checkDate.GroupBy(b => b.SupplierItem.ItemId).Select(g => new SuppliedItemPriceModel()
            {
                ItemId = g.Key,
                AveItemPrice = g.Sum(b => b.PurchaseItemQuantity * b.SupplierItem.TenderPrice) / g.Sum(c => c.PurchaseItemQuantity)
            }).ToList();

            // Get each department's charge back:
            var resultSet = from first in firstSet
                            join second in secondSet on first.ItemId equals second.ItemId
                            select new DeptExpenditureViewModel()
                            {
                                DepartmentName = first.DepartmentName,
                                DepartmentAmount = second.AveItemPrice * first.DeptItemTotal
                            };

            var result = resultSet.GroupBy(x => x.DepartmentName).Select(g => new DeptExpenditureViewModel()
            {
                DepartmentName = g.Key,
                DepartmentAmount = g.Sum(b => b.DepartmentAmount)
            }).ToList();


            if (result.Count > 0)
                return result.ToList();
            else
                return null;
        }
        //-----------------------------------------------------------------------------------------
        // Generate Stationery Requisition Trend Analysis Report:
        public List<TrendAnalysisReportViewModel> GenerateTrendAnalysisRpt(TrendAnalysisViewModel tar)
        {
            var firstResultSet = db.Disbursements.Where(x => x.ItemId == tar.ItemId
            && x.RetrievalDate >= tar.StartDate
            && x.RetrievalDate <= tar.EndDate
        ).Select(g => new TrendAnalysisReportViewModel()
        {
            ItemId = g.ItemId,
            ItemName = g.Item.ItemDescription,
            DepartmentId = g.DepartmentId,
            DepartmentName = g.Department.DepartmentName,
            RequisitionQuantity = (int)g.ActualQuantity,
            RequisitionDate = (DateTime)g.RetrievalDate
        }).ToList();

            var result = firstResultSet.Where(x => tar.DepartmentIds.Contains(x.DepartmentId)).ToList();

            if (result.Count > 0)
                return result;
            else
                return null;
        }
        //-----------------------------------------------------------------------------------------------------
        //Reorder Report (StoreSupervisor, StoreManager):
        public List<ReorderReportViewModel> GetReorderReport()
        {
            db.Configuration.ProxyCreationEnabled = true;
            db.Configuration.LazyLoadingEnabled = true;
            //Get all Low Stock Item Ids:
            var allLowStockItemIds = db.Items.Where(x => x.QuantityOnHand < x.ReorderLevel).Select
                (y => y.ItemId).ToList();
            //Get all SuppliertItemIds where ItemId == Low Stock Item Ids:
            var allSupplierItemIdsForLowStockItems = db.SupplierItems.
                Where(x => allLowStockItemIds.Contains(x.ItemId)).Select(y => y.SupplierItemId).ToList();
            // Get this month and this year
            int thisMonth = DateTime.Now.Month;
            int thisYear = DateTime.Now.Year;
            var result = db.PurchaseOrderDetails.Where(x => allSupplierItemIdsForLowStockItems.Contains(x.SupplierItemId)
            && x.PurchaseOrder.PurchaseOrderDate.Month == thisMonth && x.PurchaseOrder.PurchaseOrderDate.Year == thisYear).
            AsEnumerable().
                Select(g => new ReorderReportViewModel()
                {
                    ItemId = g.SupplierItem.ItemId,
                    ItemDescription = g.SupplierItem.Item.ItemDescription,
                    ReorderLevel = g.SupplierItem.Item.ReorderLevel,
                    ReorderQuantity = g.SupplierItem.Item.ReorderQuantity,
                    QuantityOnHand = g.SupplierItem.Item.QuantityOnHand,
                    PurchaseQuantity = g.PurchaseItemQuantity,
                    PurchaseOrderId = g.PurchaseOrderId,
                    ExpectedDate = g.PurchaseOrder.ExpectedDate.GetValueOrDefault()

                }).ToList();

            return result;
        }

        //--------------------------------------------------------------------------------------------
        // Maintain Supplier Info:
        //Supplier Info Related
        public Supplier GetSupplierById(int sprid)
        {
            return db.Suppliers.Where(x => x.SupplierId == sprid).Single();
        }

        public List<Supplier> GetAllSuppliers()
        {
            //db.Configuration.ProxyCreationEnabled = false;
            return db.Suppliers.ToList();

        }

        public int UpdateSupplier(Supplier supplier)
        {
            Supplier spr = GetSupplierById(supplier.SupplierId);
            if (supplier != null)
            {
                spr.Address = supplier.Address;
                spr.ContactName = supplier.ContactName;
                spr.Email = supplier.Email;
                spr.FaxNo = supplier.FaxNo;
                spr.GstRegistrationNo = supplier.GstRegistrationNo;
                spr.PhoneNo = supplier.PhoneNo;
                spr.Status = supplier.Status;
                spr.Remark = supplier.Remark;
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public int CreateNewSupplier(Supplier supplier)
        {
            try
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CreateSupplierItem(SupplierItem item)
        {
            try
            {
                SupplierItem newItem = new SupplierItem();

                newItem.SupplierId = item.SupplierId;
                newItem.ItemId = item.ItemId;
                newItem.TenderPrice = item.TenderPrice;
                newItem.Remark = item.Remark;
                newItem.Status = item.Status;
                newItem.Priority = item.Priority;
                var measurementUnit = db.Items.Where(x => x.ItemId == item.ItemId).Select(y => y.UnitId).FirstOrDefault();
                newItem.UnitId = measurementUnit;

                db.SupplierItems.Add(newItem);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int DeleteSupplierItem(int id)
        {
            try
            {
                SupplierItem thisItem = db.SupplierItems.Where(x => x.SupplierItemId == id).First();
                db.SupplierItems.Remove(thisItem);
                db.SaveChanges();
                return 1;
            }
            catch { return 0; }

        }

        public int UpdateSupplierItem(SupplierItem item)
        {

            SupplierItem supplierItem = GetSupplierItemById(item.SupplierItemId);
            if (supplierItem != null)
            {
                supplierItem.TenderPrice = item.TenderPrice;
                supplierItem.Remark = item.Remark;
                supplierItem.Status = item.Status;
                supplierItem.Priority = item.Priority;
                db.SaveChanges();
                return 1;
            }

            return 0;
        }

        public SupplierItem GetSupplierItemById(int id)
        {
            //db.Configuration.ProxyCreationEnabled = false;
            return db.SupplierItems.Where(x => x.SupplierItemId == id).FirstOrDefault();
        }

        //SupplierItemListViewModel
        public List<SupplierItemViewModel> GetSupplierItemListById(int sprid)
        {
            //db.Configuration.ProxyCreationEnabled = false;
            //return db.SupplierItems.Where(x => x.SupplierId == sprid).ToList();
            var result = db.SupplierItems.Where(x => x.SupplierId == sprid).Select(g => new SupplierItemViewModel
            {
                SupplierId = g.SupplierId,
                SupplierName = g.Supplier.SupplierName,
                SupplierItemId = g.SupplierItemId,
                ItemId = g.ItemId,
                ItemDescription = g.Item.ItemDescription,
                UnitName = g.Item.MeasurementUnit.UnitName,
                TenderPrice = g.TenderPrice,
                Status = g.Status,
                Remark = g.Remark,
                Priority = g.Priority
            }).ToList();

            var checkItems = db.SupplierItems.Where(x => x.SupplierId == sprid).FirstOrDefault();

            if (checkItems == null)
            {
                return null;
            }
            else
                return result;
        }
        public List<MeasurementUnit> MeasurementUnit()
        {
            //db.Configuration.ProxyCreationEnabled = false;
            return db.MeasurementUnits.ToList();
        }

        public List<ItemLocation> GetAllLocations()
        {
            //db.Configuration.ProxyCreationEnabled = false;
            return db.ItemLocations.ToList();
        }

        public int UpdateItem(Item item)
        {
            Item itm = db.Items.Where(x => x.ItemId == item.ItemId).First();
            if (itm != null)
            {
                itm.ReorderLevel = item.ReorderLevel;
                itm.ReorderQuantity = item.ReorderQuantity;
                itm.QuantityOnHand = item.QuantityOnHand;
                itm.LocationId = item.LocationId;
                itm.ItemLocation = item.ItemLocation;
                itm.Remark = item.Remark;
                if (itm.QuantityOnHand <= itm.ReorderLevel)
                {
                    itm.Status = Convert.ToString((int)InventoryStatus.UnAvailable);
                }
                else
                {
                    itm.Status = Convert.ToString((int)InventoryStatus.Available);
                }
                db.SaveChanges();
                return 1;
            }
            else { return 0; }
        }

        public int CreateItem(Item item)
        {
            try
            {
                db.Items.Add(item);
                db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<EmployeeModel> getAllEmpByDept(int deptid, string deptHeadID)
        {
            try
            {
                //db.Configuration.ProxyCreationEnabled = false;
                return db.AspNetUsers.Where(x => x.DepartmentId == deptid && x.Id != deptHeadID && x.RepStatus == 0).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*Android Team*/
        public IList<ItemRequisitionsViewModel> GetRequisitionByDeptId(String empId)
        {
            // int opened = (int)RequisitionStatus.Opened;
            int pending = (int)RequisitionStatus.Pending;
            string pending2 = Convert.ToString((int)RequisitionDetailStatus.Pending);

            try
            {
                //db.Configuration.ProxyCreationEnabled = false;
                ////db.Configuration.LazyLoadingEnabled = false;
                int deptId = db.AspNetUsers.Where(x => x.Id == empId).Select(s => s.DepartmentId).First();

                //   IList<ItemRequisitionsViewModel> lst = db.ItemRequisitions.Where(z => z.Employee.DepartmentId == deptId & z.FormStatus == opened & z.ItemRequisitionDetails.Count > 0 & z.ItemRequisitionDetails.Where(i => i.ApproveStatus == pending).Count() > 0).Select(s => new ItemRequisitionsViewModel
                IList<ItemRequisitionsViewModel> lst = db.ItemRequisitions.Where(z => z.Employee.DepartmentId == deptId & z.FormStatus == pending & z.ItemRequisitionDetails.Count > 0 & z.ItemRequisitionDetails.Where(i => i.ApproveStatus == pending2).Count() > 0).Select(s => new ItemRequisitionsViewModel
                {
                    RequisitionId = s.RequisitionId,
                    EmployeeId = s.EmployeeId,
                    EmployeeName = db.AspNetUsers.Where(x => x.Id == s.EmployeeId).Select(c => c.EmployeeName).FirstOrDefault(),
                    RequisitionDate = s.RequisitionDate,
                    FormStatus = s.FormStatus,
                    Status = s.Status,
                    ReceiveDate = s.ReceiveDate,
                    Remark = s.Remark,
                    ApproveDate = s.ApproveDate,
                    ApproveStatus = s.ApproveStatus
                }).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ItemRequisition> GetEmpItemRequisition(string empId)
        {
            try { return db.ItemRequisitions.Where(x => x.EmployeeId == empId).ToList(); }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public int UpdateItemRequisitionDetail(ItemRequisitionDetail item)
        {
            try
            {
                ItemRequisitionDetail itemRequisitionDetail = GetItemRequisitionDetailById(item.RequisitionDetailsId);

                if (itemRequisitionDetail != null)
                {
                    db.ItemRequisitions.Where(x => x.RequisitionId == itemRequisitionDetail.RequisitionId).First().FormStatus = (int)RequisitionStatus.Opened;
                    //itemRequisitionDetail.ItemRequisition.FormStatus = (int)RequisitionStatus.Opened;
                    itemRequisitionDetail.Remark = item.Remark;
                    itemRequisitionDetail.ApproveStatus = item.ApproveStatus;
                    db.SaveChanges();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ItemRequisitionsDetailsViewModel> GetItemRequisitionDetailByreqId(int reqId, String ApproveStatus)
        {


            try
            {
                //db.Configuration.ProxyCreationEnabled = false;
                //db.Configuration.LazyLoadingEnabled = false;

                List<ItemRequisitionsDetailsViewModel> lst = db.ItemRequisitionDetails.Select(s => new ItemRequisitionsDetailsViewModel
                {
                    RequisitionDetailsId = s.RequisitionDetailsId,
                    RequisitionId = s.RequisitionId,
                    ItemId = s.ItemId,
                    ItemName = db.Items.Where(x => x.ItemId == s.ItemId).Select(c => c.ItemDescription).FirstOrDefault(),
                    NeededQuantity = s.NeededQuantity,
                    ActualQuantity = s.ActualQuantity,
                    ApproveStatus = s.ApproveStatus,
                    ReceiveStatus = s.ReceiveStatus,
                    Remark = s.Remark,
                    RetrievalDate = s.RetrievalDate

                }).Where(x => x.RequisitionId == reqId & x.ApproveStatus == ApproveStatus).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<CollectionPoint> GetCollectionPoints()
        {
            try
            {
                //db.Configuration.ProxyCreationEnabled = false;
                //db.Configuration.LazyLoadingEnabled = false;
                return db.CollectionPoints.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public EmployeeDepartmentViewModel GetDepartmentbyEmployeeId(string empId)
        {
            try
            {
                //db.Configuration.ProxyCreationEnabled = false;
                ////db.Configuration.LazyLoadingEnabled = false;

                EmployeeDepartmentViewModel lst = db.AspNetUsers.Select(s => new EmployeeDepartmentViewModel
                {
                    Id = s.Id,
                    EmployeeName = s.EmployeeName,

                    DepartmentId = db.Departments.Where(x => x.DepartmentId == s.DepartmentId).Select(c => c.DepartmentId).FirstOrDefault(),
                    DepartmentName = db.Departments.Where(x => x.DepartmentId == s.DepartmentId).Select(c => c.DepartmentName).FirstOrDefault(),
                    CollectionPointId = db.Departments.Where(x => x.DepartmentId == s.DepartmentId).Select(c => c.CollectionPointId).FirstOrDefault()

                }).Where(z => z.Id == empId).First();
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public IList<StationeryRetrievalView> getRetrievalListGroupByItemId()
        {
            try
            {
                IList<StationeryRetrievalView> groupItemById = getRetrievalList().GroupBy(x => new { ItemId = x.ItemId },
                               (key, values) => new StationeryRetrievalView
                               {
                                   ItemId = key.ItemId,
                                   ItemDescription = values.First().ItemDescription,
                                   NeededQuantity = values.Sum(x => x.NeededQuantity),
                                   ItemLocation = values.First().ItemLocation,
                                   QuantityOnHand = values.First().QuantityOnHand
                               }).ToList();


                return groupItemById;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<StationeryRetrievalView> getRetrievalListGroupByDepartment(int itemId)
        {
            //db.Configuration.ProxyCreationEnabled = false;
            ////db.Configuration.LazyLoadingEnabled = false;
            try
            {
                IList<StationeryRetrievalView> groupbyDeptId = getRetrievalList().GroupBy(x => new { ItemId = x.ItemId, DepartmentId = x.DepartmentId },
                               (key, values) => new StationeryRetrievalView
                               {
                                   DepartmentId = key.DepartmentId,
                                   DepartmentName = values.First().DepartmentName,
                                   ItemId = key.ItemId,
                                   ItemLocation = values.First().ItemLocation,
                                   ItemDescription = values.First().ItemDescription,
                                   NeededQuantity = values.Sum(x => x.NeededQuantity),
                                   QuantityOnHand = values.First().QuantityOnHand,
                                   // QuantityOnHand = values.First().QuantityOnHand - values.Sum(x => x.ActualQuantity)
                               }).Where(y => y.ItemId == itemId).ToList();


                return groupbyDeptId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void updateItemReqDetailsRecieveStatus(IList<StationeryRetrievalView> vm)
        {
            try
            {
                //IList<StationeryRetrievalView> groupItemById = vm.GroupBy(x => new { ItemId = x.ItemId },
                //                 (key, values) => new StationeryRetrievalView
                //                 {
                //                     ItemId = key.ItemId,
                //                     QuantityOnHand = values.First().QuantityOnHand - values.Sum(x => x.ActualQuantity)
                //                 }).ToList();
                //foreach (StationeryRetrievalView s in vm)
                //{
                //    var ird = db.ItemRequisitionDetails.Where(x => x.RequisitionDetailsId == s.RequisitionDetailsId).FirstOrDefault();
                //    ird.ActualQuantity = s.ActualQuantity;
                //    if (ird.ActualQuantity == ird.NeededQuantity)
                //    {
                //        ird.ReceiveStatus = (Convert.ToString((int)RequisitionDetailStatus.Fullfill));
                //    }
                //    else
                //    {
                //        ird.ReceiveStatus = (Convert.ToString((int)RequisitionDetailStatus.Unfulfill));
                //    }
                //    db.SaveChanges();
                //}

                IList<StationeryRetrievalView> groupItemById = vm.GroupBy(x => new { ItemId = x.ItemId },
                          (key, values) => new StationeryRetrievalView
                          {
                              ItemId = key.ItemId,
                              QuantityOnHand = values.First().QuantityOnHand - values.Sum(x => x.ActualQuantity)
                          }).ToList();

                //update receive status
                foreach (StationeryRetrievalView s in vm)
                {
                    //breakdown by individual requested qty
                    var breakdownBIndividual = vm.Where(x => x.ItemId == s.ItemId && x.DepartmentId == s.DepartmentId).ToList();

                    var gropbyItem = db.ItemRequisitionDetails.AsEnumerable().Where(x => breakdownBIndividual.Select(v => v.RequisitionDetailsId.ToString()).ToList().Contains(x.RequisitionDetailsId.ToString()))
                        .Select(e => new { e.RequisitionDetailsId, e.NeededQuantity }).ToList();

                    var calcIndvAtualQty = (gropbyItem.Where(x => x.RequisitionDetailsId == s.RequisitionDetailsId)
                        .Select(t => (double)t.NeededQuantity).First() / gropbyItem.Select(t => (double)t.NeededQuantity).Sum())
                        * (double)breakdownBIndividual.First().ActualQuantity;

                    var ird = db.ItemRequisitionDetails.Where(x => x.RequisitionDetailsId == s.RequisitionDetailsId).FirstOrDefault();
                    ird.ActualQuantity += Convert.ToInt32(calcIndvAtualQty);
                    if (ird.ActualQuantity == ird.NeededQuantity)
                    {
                        ird.ReceiveStatus = (Convert.ToString((int)RequisitionDetailStatus.Fullfill));
                    }
                    else
                    {
                        ird.ReceiveStatus = (Convert.ToString((int)RequisitionDetailStatus.Unfulfill));
                    }
                    ird.ActualQuantity = s.ActualQuantity;
                    db.SaveChanges();
                }

                //update avaliable status of item table
                foreach (StationeryRetrievalView qty in groupItemById)
                {
                    var checkInv = db.Items.Where(s => s.ItemId == qty.ItemId).FirstOrDefault();
                    checkInv.QuantityOnHand = qty.QuantityOnHand;
                    if (checkInv.QuantityOnHand <= 0)
                    {
                        checkInv.Status = Convert.ToString((int)InventoryStatus.UnAvailable);
                    }
                    else
                    {
                        checkInv.Status = Convert.ToString((int)InventoryStatus.Available);
                    }
                    db.SaveChanges();
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void createDisbursement(IList<StationeryRetrievalView> vm)
        {
            try
            {
                //IList<Disbursement> disbursements = new List<Disbursement>();

                //IList<StationeryRetrievalView> groupItemById = vm.GroupBy(x => new { ItemId = x.ItemId },
                //           (key, values) => new StationeryRetrievalView
                //           {
                //               ItemId = key.ItemId,
                //               QuantityOnHand = values.First().QuantityOnHand - values.Sum(x => x.ActualQuantity)
                //           }).ToList();


                //List<StationeryRetrievalView> saveToDis = vm.GroupBy(g => new { ItemId = g.ItemId, DepartmentId = g.DepartmentId }, (key, values) => new StationeryRetrievalView
                //{
                //    ItemId = key.ItemId,
                //    DepartmentId = key.DepartmentId,
                //    NeededQuantity = values.First().NeededQuantity,
                //    ActualQuantity = values.First().ActualQuantity
                //}).ToList();
                //foreach (StationeryRetrievalView stationery in saveToDis)
                //{
                //    disbursements.Add(new Disbursement
                //    {
                //        ItemId = stationery.ItemId,
                //        DepartmentId = stationery.DepartmentId,
                //        ActualQuantity = stationery.ActualQuantity,
                //        NeededQuantity = stationery.NeededQuantity,
                //        RetrievalDate = DateTime.Now.Date,
                //        ACKStatus = Convert.ToString((int)DisbursementAckStatus.Unackowledge),
                //        Status = stationery.RequisitionDetailsId
                //    });
                //}

                //db.Disbursements.AddRange(disbursements);
                //db.SaveChanges();

                //foreach (StationeryRetrievalView qty in groupItemById)
                //{
                //    var checkInv = db.Items.Where(s => s.ItemId == qty.ItemId).FirstOrDefault();
                //    checkInv.QuantityOnHand = qty.QuantityOnHand;
                //    if (checkInv.QuantityOnHand <= 0)
                //    {
                //        checkInv.Status = Convert.ToString((int)InventoryStatus.UnAvailable);
                //    }
                //    else
                //    {
                //        checkInv.Status = Convert.ToString((int)InventoryStatus.Available);
                //    }
                //    db.SaveChanges();
                //}

                IList<Disbursement> disbursements = new List<Disbursement>();
                //calc Qty on hand
                IList<StationeryRetrievalView> groupItemById = vm.GroupBy(x => new { ItemId = x.ItemId },
                             (key, values) => new StationeryRetrievalView
                             {
                                 ItemId = key.ItemId,
                                 QuantityOnHand = values.First().QuantityOnHand - values.Sum(x => x.ActualQuantity)
                             }).ToList();


                //create Dis
                foreach (StationeryRetrievalView stationery in vm.Where(x => x.ActualQuantity > 0).ToList())
                {
                    var breakdownBIndividual = vm.Where(x => x.ItemId == stationery.ItemId && x.DepartmentId == stationery.DepartmentId).ToList();
                    var gropbyItem = db.ItemRequisitionDetails.AsEnumerable().Where(x => breakdownBIndividual.Select(v => v.RequisitionDetailsId.ToString()).ToList().Contains(x.RequisitionDetailsId.ToString()))
                        .Select(e => new { e.RequisitionDetailsId, e.NeededQuantity }).ToList();

                    var calcIndvAtualQty = (gropbyItem.Where(x => x.RequisitionDetailsId == stationery.RequisitionDetailsId)
                        .Select(t => (double)t.NeededQuantity).First() / gropbyItem.Select(t => (double)t.NeededQuantity).Sum())
                        * (double)breakdownBIndividual.First().ActualQuantity;

                    var isExistingDis = db.Disbursements.Where(x => x.Status == stationery.RequisitionDetailsId).FirstOrDefault();

                    if (isExistingDis == null)
                    {
                        disbursements.Add(new Disbursement
                        {
                            ItemId = stationery.ItemId,
                            DepartmentId = stationery.DepartmentId,
                            ActualQuantity = (int)calcIndvAtualQty,
                            NeededQuantity = db.ItemRequisitionDetails.Where(x => x.RequisitionDetailsId == stationery.RequisitionDetailsId).FirstOrDefault().NeededQuantity,
                            RetrievalDate = DateTime.Now.Date,
                            ACKStatus = Convert.ToString((int)DisbursementAckStatus.Unackowledge),
                            Status = stationery.RequisitionDetailsId
                        });
                    }
                    else
                    {
                        var d = db.Disbursements.Where(x => x.Status == stationery.RequisitionDetailsId).FirstOrDefault();
                        d.NeededQuantity = d.NeededQuantity - d.ActualQuantity;
                        d.ActualQuantity = (int)calcIndvAtualQty;
                    }
                }

                db.Disbursements.AddRange(disbursements);
                db.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<DisbursementViewModel> getDisbursementbyDepartment()
        {
            try
            {
                //db.Configuration.ProxyCreationEnabled = false;
                ////db.Configuration.LazyLoadingEnabled = false;
                //  int cid=db.Departments.Where(x=>x.CollectionPointId==)

                List<DisbursementViewModel> lst = db.Disbursements.Select(s => new DisbursementViewModel
                {
                    DisbursementId = s.DisbursementId,
                    DepartmentId = s.DepartmentId,
                    DepartmentName = s.Department.DepartmentName,
                    ItemId = s.ItemId,
                    ItemDescription = s.Item.ItemDescription,
                    NeededQuantity = (int)s.NeededQuantity,
                    ActualQuantity = (int)s.ActualQuantity,
                    QRCode = s.QRCode,
                    ReturnQuantity = s.ReturnQuantity,
                    Reason = s.Reason,
                    ACKStatus = s.ACKStatus,
                    collectionpoint = s.Department.CollectionPoint.CollectionPointAddress
                }).Where(x=>x.ACKStatus=="0").ToList();

                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<DisbursementViewModel> getDisbursementbyDeptID(int deptId)
        {


            try
            {



                List<DisbursementViewModel> disbursement = getDisbursementbyDepartment().AsEnumerable().Where(x => x.DepartmentId == deptId & x.ACKStatus == Convert.ToString((int)DisbursementAckStatus.Unackowledge))
                   .GroupBy(g => new { ItemId = g.ItemId }, (key, values) => new DisbursementViewModel
                   {
                       ItemId = key.ItemId,
                       DepartmentId = values.First().DepartmentId,
                       DepartmentName = values.First().DepartmentName,
                       //  ItemId = values.First().ItemId,
                       ItemDescription = values.First().ItemDescription,
                       NeededQuantity = (int)values.First().NeededQuantity,
                       ActualQuantity = (int)values.First().ActualQuantity,
                       QRCode = values.First().QRCode,
                       ReturnQuantity = values.First().ReturnQuantity,
                       Reason = values.First().Reason,
                       ACKStatus = values.First().ACKStatus,
                       collectionpoint = values.First().collectionpoint
                   }).ToList();

                return disbursement;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }









        public void updateQRCode(IList<DisbursementViewModel> vm)
        {

            string code = "";
            string deptName;
            try
            {





                String ack = Convert.ToString((int)DisbursementAckStatus.Unackowledge);

                DisbursementViewModel dv = vm[0];
                int deptId = dv.DepartmentId;

                List<Disbursement> lst = db.Disbursements.Where(x => x.DepartmentId == deptId && x.ACKStatus == "0").ToList();


                foreach (Disbursement s in lst)
                {
                    deptName = db.Departments.Where(x => x.DepartmentId == s.DepartmentId).First().DepartmentName;
                    int disId = db.Disbursements.Where(x => x.DepartmentId == s.DepartmentId & x.ACKStatus == ack).First().DisbursementId;
                    code = deptName.Substring(0, 3).ToUpper() + disId.ToString();




                    db.Disbursements.Where(z => z.DisbursementId == s.DisbursementId).First().QRCode = code;
                    db.SaveChanges();

                }




                //String ack = Convert.ToString((int)DisbursementAckStatus.Unackowledge);
                //foreach (DisbursementViewModel s in vm)
                //{

                //    deptName = db.Departments.Where(x => x.DepartmentId == s.DepartmentId).First().DepartmentName;


                //    int disId = db.Disbursements.Where(x => x.DepartmentId == s.DepartmentId & x.ACKStatus == Convert.ToString((int)DisbursementAckStatus.Unackowledge)).First().DisbursementId;
                //    code = deptName.Substring(0, 3).ToUpper() + disId.ToString();

                //    db.Disbursements.Where(x => x.DepartmentId == s.DepartmentId && x.ACKStatus == ack).First().QRCode = code;
                //    db.SaveChanges();
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DisbursementViewModel getDisbursementbyId(int disId)
        {
            try
            {
                DisbursementViewModel disbursement = getDisbursementbyDepartment().Where(x => x.DisbursementId == disId).First();

                return disbursement;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void updateDisbursementById(DisbursementViewModel vm)
        {
            try
            {
                var dis = db.Disbursements.Where(x => x.DisbursementId == vm.DisbursementId).FirstOrDefault();
                dis.ReturnQuantity = vm.ReturnQuantity;
                dis.ActualQuantity = vm.ActualQuantity;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<CategoryItemViewModel> GetCategoriesItem(string cat)
        {
            try
            {
                List<CategoryItemViewModel> list = db.Items.Select<Item, CategoryItemViewModel>
                    (c => new CategoryItemViewModel()
                    {
                        CategoryId = c.CategoryId,
                        CategoryName = db.Categories.Where(x => x.CategoryId == c.CategoryId).Select(y => y.CategoryName).FirstOrDefault(),
                        ItemId = c.ItemId,
                        ItemDescription = c.ItemDescription,
                        QuantityOnHand = db.ItemAdjustments.Where(x => x.ItemId == c.ItemId).Select(y => y.AdjustmentQuantity).FirstOrDefault(),
                        Status = db.ItemAdjustments.Where(x => x.ItemId == c.ItemId).Select(y => y.Status).FirstOrDefault(),
                        Reason = db.ItemAdjustments.Where(x => x.ItemId == c.ItemId).Select(y => y.Reason).FirstOrDefault(),
                        AdjustmentQuantity = db.ItemAdjustments.Where(x => x.ItemId == c.ItemId).Select(y => y.AdjustmentQuantity).FirstOrDefault(),
                        ItemAdjustmentDate = db.ItemAdjustments.Where(x => x.ItemId == c.ItemId).Select(y => y.ItemAdjustmentDate).FirstOrDefault()

                    }).Where(z => z.CategoryName == cat).ToList<CategoryItemViewModel>();

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public CategoryItemViewModel GetItem(String item)
        {
            try
            {
                CategoryItemViewModel list = db.Items.Where(y => y.ItemDescription == item).Select<Item, CategoryItemViewModel>
                    (c => new CategoryItemViewModel()
                    {
                        CategoryId = c.CategoryId,
                        CategoryName = db.Categories.Where(x => x.CategoryId == c.CategoryId).Select(y => y.CategoryName).FirstOrDefault(),
                        ItemId = c.ItemId,
                        ItemDescription = c.ItemDescription,
                        QuantityOnHand = c.QuantityOnHand,
                        Status = db.ItemAdjustments.Where(x => x.ItemId == c.ItemId).Select(y => y.Status).FirstOrDefault(),
                        Reason = db.ItemAdjustments.Where(x => x.ItemId == c.ItemId).Select(y => y.Reason).FirstOrDefault(),
                        AdjustmentQuantity = db.ItemAdjustments.Where(x => x.ItemId == c.ItemId).Select(y => y.AdjustmentQuantity).FirstOrDefault(),
                        ItemAdjustmentDate = db.ItemAdjustments.Where(x => x.ItemId == c.ItemId).Select(y => y.ItemAdjustmentDate).FirstOrDefault()

                    }).FirstOrDefault();

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<CategoryItemViewModel> GetAllItem()
        {
            try
            {
                List<CategoryItemViewModel> list = db.ItemAdjustments.AsEnumerable().Where(b => b.Status == Convert.ToString((int)ItemAdjustmentStatus.Unsubmitted)).Select<ItemAdjustment, CategoryItemViewModel>
                    (c => new CategoryItemViewModel()
                    {
                        EmployeeId = c.EmployeeId,
                        ItemId = c.ItemId,
                        ItemDescription = db.Items.Where(x => x.ItemId == c.ItemId).Select(y => y.ItemDescription).FirstOrDefault(),
                        QuantityOnHand = db.Items.Where(x => x.ItemId == c.ItemId).Select(y => y.QuantityOnHand).FirstOrDefault(),
                        Status = db.ItemAdjustments.Where(x => x.ItemId == c.ItemId).Select(y => y.Status).FirstOrDefault(),
                        Reason = db.ItemAdjustments.Where(x => x.ItemId == c.ItemId).Select(y => y.Reason).FirstOrDefault(),
                        AdjustmentQuantity = db.ItemAdjustments.Where(x => x.ItemId == c.ItemId).Select(y => y.AdjustmentQuantity).FirstOrDefault(),
                        ItemAdjustmentDate = db.ItemAdjustments.Where(x => x.ItemId == c.ItemId).Select(y => y.ItemAdjustmentDate).FirstOrDefault()

                    }).ToList();

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<ItemAdjustment> GetAdjItemByEmpId(string id)
        {
            try
            {
                List<ItemAdjustment> list = db.ItemAdjustments.Where(y => y.Status == "0" && y.EmployeeId == id).ToList();

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public IList<ItemAdjustmentViewModel> getUnsubmittedAdjItems(String empId)
        {
            try
            {
                IList<ItemAdjustmentViewModel> adjs = db.ItemAdjustments.AsEnumerable().Where(s =>
                s.Status == Convert.ToString((int)ItemAdjustmentStatus.Unsubmitted) && s.EmployeeId == empId)
                    .Select(s => new ItemAdjustmentViewModel
                    {
                        //  ItemAdjustmentId = s.ItemAdjustmentId,
                        ItemId = s.ItemId,
                        //  Reason = s.Reason,
                        Remark = s.Remark,
                        EmployeeId = s.EmployeeId,
                        AdjustmentQuantity = s.AdjustmentQuantity,
                        ItemAdjustmentDate = s.ItemAdjustmentDate,
                        Status = s.Status,
                        Item = db.Items.Where(x => x.ItemId == s.ItemId).Select(e => new ItemViewModel
                        {
                            ItemId = e.ItemId,
                            ItemDescription = e.ItemDescription,
                            QuantityOnHand = e.QuantityOnHand,
                            // MeasurementUnit = db.MeasurementUnits.Where(h => h.UnitId == e.UnitId).Select(j => new MeasurementUnitViewModel { UnitId = j.UnitId, UnitName = j.UnitName }).FirstOrDefault(),
                        }).FirstOrDefault()
                    }).ToList();

                return adjs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public bool submitAdjItem(List<ItemAdjustment> adjs, string id)
        {
            try
            {
                List<ItemAdjustment> items = GetAdjItemByEmpId(id);
                foreach (ItemAdjustment item in items)
                {
                    item.Status = Convert.ToString((int)ItemAdjustmentStatus.Submitted);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<DisbursementViewModel> GetDisItemByDepId(int depId, string qrCode)
        {
            try
            {
                List<DisbursementViewModel> list = getDisbursementbyDeptID(depId).Where(y => y.QRCode == qrCode).ToList();

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public bool afterQRScan(Disbursement adjs, string id)
        {
            try
            {
                EmployeeModel employee = GetEmpById(id);
                if (employee != null && adjs != null)
                {
                    if (employee.RepStatus == 1)
                    {
                        int depId = employee.DepartmentId;
                        string qrcode = adjs.QRCode;
                        List<Disbursement> items = GetDisItemByCheckAck0(depId, qrcode);
                        if (items.Count != 0)
                        {
                            foreach (Disbursement item in items)
                            {
                                item.ACKStatus = "1";
                                item.CollectDate = DateTime.Now;
                            }
                            db.SaveChanges();
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }

                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int delegateDH(EmployeeModel emp, string na)
        {
            EmployeeModel employee = GetEmpById(emp.Id);
            if (employee != null)
            {
                employee.AuthorityStartDate = emp.AuthorityStartDate;
                employee.AuthorityEndDate = emp.AuthorityEndDate;
                employee.DelegationStatus = 1;
                db.SaveChanges();
                _userManager.AddToRole(employee.Id, "TemporaryDepartmentHead");
                EmailNotification.SendDelegationEmail(emp.Id, na);


                return 1;
            }
            return 0;
        }

        public int cancelDelegateDH(EmployeeModel emp)
        {

            EmployeeModel employee = GetEmpById(emp.Id);
            if (employee != null)
            {
                employee.AuthorityStartDate = null;
                employee.AuthorityEndDate = null;
                employee.DelegationStatus = 0;
                db.SaveChanges();
                var upd = _userManager.Update(employee);
                var rolesForUser = _userManager.GetRoles(employee.Id);


                if (rolesForUser.Count() > 0 && upd.Succeeded)
                {
                    foreach (var item in rolesForUser.ToList())
                    {
                        var result = _userManager.RemoveFromRole(employee.Id, "TemporaryDepartmentHead");
                        return 1;
                    }
                }

            }
            return 0;
        }

        public int assignRep(EmployeeModel emp)
        {
            EmployeeModel repemp = GetEmployeebyRepStatus();
            if (repemp != null)
            {
                repemp.RepStatus = 0;
                _userManager.RemoveFromRole(repemp.Id,"DepartmentRep");
            }

            EmployeeModel employee = GetEmpById(emp.Id);
            if (employee != null)
            {

                employee.RepStatus = 1;
                employee.AuthorityEndDate = emp.AuthorityEndDate;
                db.SaveChanges();
                _userManager.AddToRole(employee.Id, "DepartmentRep");
                return 1;
            }
            return 0;
        }

        public EmployeeModel GetEmpById(String Id)
        {
            return db.AspNetUsers.Where(s => s.Id == Id).FirstOrDefault();
        }

        public EmployeeModel GetEmployeebyRepStatus()
        {
            return db.AspNetUsers.Where(s => s.RepStatus == 1).FirstOrDefault();
        }

        public List<DisbursementViewModel> afterQRDisbList(String QRCode, string id)
        {
            try
            {
                EmployeeModel employee = GetEmpById(id);
                if (employee != null && QRCode != null)
                {
                    if (employee.RepStatus == 1)
                    {
                        int depId = employee.DepartmentId;
                        string qrcode = QRCode;
                        List<DisbursementViewModel> adjs = GetDisListByDepId(depId, qrcode);
                        return adjs;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<DisbursementViewModel> GetDisListByDepId(int depId, string qrCode)
        {
            try
            {
                List<DisbursementViewModel> list = getDisbursementbyDeptIDwithAck(depId).Where(y => (y.QRCode == qrCode)).ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //TOE
        public IList<DisbursementViewModel> getDisbursementbyDeptIDwithAck(int deptId)
        {
            try
            {
                // List<DisbursementViewModel> disbursement = getDisbursementbyDepartment().AsEnumerable().Where(x => x.DepartmentId == deptId & x.ACKStatus == Convert.ToString((int)DisbursementAckStatus.Acknowledge))
                //    .ToList();
                List<DisbursementViewModel> lst = db.Disbursements.Select(s => new DisbursementViewModel
                {
                    DisbursementId = s.DisbursementId,
                    DepartmentId = s.DepartmentId,
                    DepartmentName = s.Department.DepartmentName,
                    ItemId = s.ItemId,
                    ItemDescription = s.Item.ItemDescription,
                    NeededQuantity = (int)s.NeededQuantity,
                    ActualQuantity = (int)s.ActualQuantity,
                    QRCode = s.QRCode,
                    ReturnQuantity = s.ReturnQuantity,
                    Reason = s.Reason,
                    ACKStatus = s.ACKStatus,
                    collectionpoint = s.Department.CollectionPoint.CollectionPointAddress
                }).ToList();

                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //ExistQR with ACK=0
        public IList<DisbursementViewModel> getDisbDetail(int disId, string id)
        {
            try
            {
                EmployeeModel employee = GetEmpById(id);
                if (employee != null && disId != 0)
                {
                    if (employee.RepStatus == 1)
                    {
                        int depId = employee.DepartmentId;
                        int disbId = disId;
                        List<DisbursementViewModel> adjs = GetDisListByDisbId(depId, disbId);
                        return adjs;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<DisbursementViewModel> GetDisListByDisbId(int depId, int disbId)
        {
            try
            {
                List<DisbursementViewModel> list = getDisbursementbyDeptIDwithAck(depId).Where(y => (y.DisbursementId == disbId)).ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public IList<DisbursementViewModel> existQRCode(String QRCode, string id)
        {
            try
            {
                EmployeeModel employee = GetEmpById(id);
                if (employee != null && QRCode != null)
                {
                    if (employee.RepStatus == 1)
                    {
                        int depId = employee.DepartmentId;
                        string qrcode = QRCode;
                        List<DisbursementViewModel> adjs = GetDisItemByDepIdCheckAck0(depId, qrcode);
                        return adjs;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get List
        public List<DisbursementViewModel> GetDisItemByDepIdCheckAck0(int deptId, string qrCode)
        {
            try
            {
                List<DisbursementViewModel> disbursement = getDisbursementbyDepartment().AsEnumerable().Where(x => x.QRCode == qrCode & x.DepartmentId == deptId & x.ACKStatus == Convert.ToString((int)DisbursementAckStatus.Unackowledge))
                   .ToList();

                return disbursement;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Disbursement> GetDisItemByCheckAck0(int deptId, string qrCode)
        {
            try
            {
                List<Disbursement> list = db.Disbursements.Where(y => (y.DepartmentId == deptId) && (y.QRCode == qrCode) && (y.ACKStatus == "0")).ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public enum RequisitionStatus
        {
            Closed = 0,
            Opened = 1,
            Pending = 2
        }
        public enum RequisitionDetailStatus
        {
            /*For ReceivedStatus*/
            NA = 0,
            Unfulfill = 1,
            Fullfill = 2,
            /*For ApproveStatus*/
            Approved = 3,
            Rejected = 4,
            Pending = 5
        }

        public enum InventoryStatus
        {
            UnAvailable = 0,
            Available = 1,
            Ordered = 2
        }
        public enum PurchaseOrderDetailStatus
        {
            NA = 0,
            Pending = 1,
            Delivered = 2,
            Confirmed = 3,
            Cancelled = 4
        }
        public enum ItemAdjustmentStatus
        {
            Unsubmitted = 0,
            Submitted = 1,
            Approved = 2,
        }
        public enum PurchaseOrderStatus
        {
            NA = 0,
            Open = 1,
            Closed = 2
        }
        public enum SupplierStatus
        {
            Inactive = 0,
            Active = 1
        }
        public enum DisbursementAckStatus
        {
            Unackowledge = 0,
            Acknowledge = 1
        }
    }

    public static class APIErrors
    {
        public static System.Net.Http.HttpResponseMessage ApiError(string message)
        {
            var response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            response.ReasonPhrase = message;
            response.Content = new System.Net.Http.StringContent(message);
            //throw new System.Web.Http.HttpResponseException(response);
            return response;
        }
    }
    
}