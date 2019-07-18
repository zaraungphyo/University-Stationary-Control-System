namespace RestAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;

    public partial class ssisdbContext : IdentityDbContext
    {
        public ssisdbContext()
            : base("name=potato")
        {
             Database.SetInitializer<ssisdbContext>(new CreateDatabaseIfNotExists<ssisdbContext>());

            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

        }
        public static ssisdbContext Create()
        {
            return new ssisdbContext();
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CollectionPoint> CollectionPoints { get; set; }
        public virtual DbSet<DelegationRecord> DelegationRecords { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Disbursement> Disbursements { get; set; }
      //  public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemAdjustment> ItemAdjustments { get; set; }
        public virtual DbSet<ItemLocation> ItemLocations { get; set; }
        public virtual DbSet<ItemRequisition> ItemRequisitions { get; set; }
        public virtual DbSet<ItemRequisitionDetail> ItemRequisitionDetails { get; set; }
        public virtual DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierItem> SupplierItems { get; set; }
     //   public virtual DbSet<StationeryRetrievalView> StationeryRetrievalView { get; set; }
        public virtual DbSet<EmployeeModel> AspNetUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MeasurementUnit>()
                .Property(e => e.UnitId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<MeasurementUnit>()
                .Property(e => e.UnitName)
                .IsUnicode(false);

            modelBuilder.Entity<MeasurementUnit>()
                .HasMany(e => e.Items)
                .WithRequired(e => e.MeasurementUnit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MeasurementUnit>()
                .HasMany(e => e.SupplierItems)
                .WithRequired(e => e.MeasurementUnit)
                .WillCascadeOnDelete(false);
            
            modelBuilder.Entity<CollectionPoint>()
                .Property(e => e.CollectionPointAddress)
                .IsUnicode(false);

            modelBuilder.Entity<CollectionPoint>()
                .Property(e => e.CollectionTime)
                .IsUnicode(false);

            modelBuilder.Entity<CollectionPoint>()
                .HasMany(e => e.Departments)
                .WithRequired(e => e.CollectionPoint)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DelegationRecord>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<DelegationRecord>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.DepartmentName)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.ContactName)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.PhoneNo)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.FaxNo)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Disbursements)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Disbursement>()
                .Property(e => e.QRCode)
                .IsUnicode(false);

            modelBuilder.Entity<Disbursement>()
                .Property(e => e.ACKStatus)
                .IsUnicode(false);

            //modelBuilder.Entity<Disbursement>()
            //    .Property(e => e.Status)
            //    .IsUnicode(true);

            modelBuilder.Entity<Disbursement>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<Disbursement>()
                .Property(e => e.Reason)
                .IsUnicode(false);

            #region
            //modelBuilder.Entity<Employee>()
            //    .Property(e => e.EmployeeName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Employee>()
            //    .Property(e => e.JobTitle)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Employee>()
            //    .Property(e => e.Salary)
            //    .HasPrecision(18, 0);

            //modelBuilder.Entity<Employee>()
            //    .Property(e => e.Remark)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Employee>()
            //    .Property(e => e.Status)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Employee>()
            //    .HasMany(e => e.DelegationRecords)
            //    .WithRequired(e => e.Employee)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Employee>()
            //    .HasMany(e => e.ItemAdjustments)
            //    .WithRequired(e => e.Employee)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Employee>()
            //    .HasMany(e => e.ItemRequisitions)
            //    .WithRequired(e => e.Employee)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Employee>()
            //    .HasMany(e => e.PurchaseOrders)
            //    .WithRequired(e => e.Employee)
            //    .WillCascadeOnDelete(false);
            #endregion

            #region Category
            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Items)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);
            #endregion

            modelBuilder.Entity<Item>()
                .Property(e => e.ItemId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Item>()
                .Property(e => e.ItemDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Disbursements)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.ItemAdjustments)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.ItemRequisitionDetails)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.SupplierItems)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);
            
            modelBuilder.Entity<ItemAdjustment>()
                .Property(e => e.Reason)
                .IsUnicode(false);

            modelBuilder.Entity<ItemAdjustment>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<ItemAdjustment>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<ItemLocation>()
                .Property(e => e.LocationDesc)
                .IsUnicode(false);

            modelBuilder.Entity<ItemRequisition>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<ItemRequisition>()
                .Property(e => e.Status);

            modelBuilder.Entity<ItemRequisition>()
                .HasMany(e => e.ItemRequisitionDetails)
                .WithRequired(e => e.ItemRequisition)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ItemRequisitionDetail>()
                .Property(e => e.ApproveStatus)
                .IsUnicode(false);

            modelBuilder.Entity<ItemRequisitionDetail>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<ItemRequisitionDetail>()
                .Property(e => e.ReceiveStatus)
                .IsUnicode(false);

            

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(e => e.PurchaseOrderDetails)
                .WithRequired(e => e.PurchaseOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            //modelBuilder.Entity<PurchaseOrderDetail>()
            //   .HasMany(e => e.Item)
            //    .WithRequired(e => e.PurchaseOrderDetail)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.SupplierName)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.ContactName)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.PhoneNo)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.FaxNo)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.GstRegistrationNo)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Email)
                .IsUnicode(false);

            //modelBuilder.Entity<Supplier>()
            //    .HasMany(e => e.PurchaseOrders)
            //    .WithRequired(e => e.Supplier)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.SupplierItems)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SupplierItem>()
                .Property(e => e.TenderPrice)
                .HasPrecision(8, 2);

            modelBuilder.Entity<SupplierItem>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<SupplierItem>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<SupplierItem>()
                .HasMany(e => e.PurchaseOrderDetails)
                .WithRequired(e => e.SupplierItem)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Item>()
            //    .HasMany(e => e.PurchaseOrderDetails)
            //    .WithRequired(e => e.SupplierItem)
            //    .WillCascadeOnDelete(false);
        }
    }
}
