namespace RestAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Password = c.String(maxLength: 100),
                        ConfirmPassword = c.String(),
                        EmployeeName = c.String(maxLength: 50),
                        JobTitle = c.String(maxLength: 30),
                        Salary = c.Decimal(precision: 18, scale: 2),
                        DepartmentId = c.Int(),
                        RepStatus = c.Int(),
                        DelegationStatus = c.Int(),
                        Remark = c.String(maxLength: 100),
                        AuthorityStartDate = c.DateTime(),
                        AuthorityEndDate = c.DateTime(),
                        Status = c.String(maxLength: 20),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DelegationRecord",
                c => new
                    {
                        DelegationId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.String(maxLength: 128),
                        StartDate = c.DateTime(nullable: false, storeType: "date"),
                        EndDate = c.DateTime(storeType: "date"),
                        Status = c.String(maxLength: 20, unicode: false),
                        Remark = c.String(maxLength: 300, unicode: false),
                    })
                .PrimaryKey(t => t.DelegationId)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 50, unicode: false),
                        ContactName = c.String(nullable: false, maxLength: 30, unicode: false),
                        PhoneNo = c.String(maxLength: 15, unicode: false),
                        FaxNo = c.String(maxLength: 15, unicode: false),
                        CollectionPointId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("dbo.CollectionPoint", t => t.CollectionPointId)
                .Index(t => t.CollectionPointId);
            
            CreateTable(
                "dbo.CollectionPoint",
                c => new
                    {
                        CollectionPointId = c.Int(nullable: false, identity: true),
                        CollectionPointAddress = c.String(nullable: false, maxLength: 100, unicode: false),
                        CollectionTime = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CollectionPointId);
            
            CreateTable(
                "dbo.Disbursement",
                c => new
                    {
                        DisbursementId = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        QRCode = c.String(maxLength: 10, unicode: false),
                        ActualQuantity = c.Int(),
                        NeededQuantity = c.Int(),
                        ReturnQuantity = c.Int(nullable: false),
                        RetrievalDate = c.DateTime(storeType: "date"),
                        ACKStatus = c.String(maxLength: 10, unicode: false),
                        Status = c.String(maxLength: 10, unicode: false),
                        Remark = c.String(maxLength: 300, unicode: false),
                        Reason = c.String(maxLength: 300, unicode: false),
                        CollectDate = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.DisbursementId)
                .ForeignKey("dbo.Item", t => t.ItemId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .Index(t => t.ItemId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        ItemDescription = c.String(nullable: false, maxLength: 100, unicode: false),
                        ReorderLevel = c.Int(nullable: false),
                        ReorderQuantity = c.Int(nullable: false),
                        QuantityOnHand = c.Int(nullable: false),
                        UnitId = c.Int(nullable: false),
                        LocationId = c.Int(),
                        Status = c.String(maxLength: 20, unicode: false),
                        Remark = c.String(maxLength: 300, unicode: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .ForeignKey("dbo.ItemLocation", t => t.LocationId)
                .ForeignKey("dbo.MeasurementUnit", t => t.UnitId)
                .Index(t => t.CategoryId)
                .Index(t => t.UnitId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.ItemAdjustment",
                c => new
                    {
                        ItemAdjustmentId = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        AdjustmentQuantity = c.Int(nullable: false),
                        Reason = c.String(maxLength: 300, unicode: false),
                        ItemAdjustmentDate = c.DateTime(nullable: false, storeType: "date"),
                        EmployeeId = c.String(maxLength: 128),
                        Status = c.String(maxLength: 20, unicode: false),
                        Remark = c.String(maxLength: 300, unicode: false),
                    })
                .PrimaryKey(t => t.ItemAdjustmentId)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployeeId)
                .ForeignKey("dbo.Item", t => t.ItemId)
                .Index(t => t.ItemId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.ItemLocation",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        LocationDesc = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "dbo.ItemRequisitionDetail",
                c => new
                    {
                        RequisitionDetailsId = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        RequisitionId = c.Int(nullable: false),
                        NeededQuantity = c.Int(nullable: false),
                        ActualQuantity = c.Int(nullable: false),
                        ApproveStatus = c.String(maxLength: 20, unicode: false),
                        RetrievalDate = c.DateTime(storeType: "date"),
                        Remark = c.String(maxLength: 300, unicode: false),
                        ReceiveStatus = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.RequisitionDetailsId)
                .ForeignKey("dbo.ItemRequisitions", t => t.RequisitionId)
                .ForeignKey("dbo.Item", t => t.ItemId)
                .Index(t => t.ItemId)
                .Index(t => t.RequisitionId);
            
            CreateTable(
                "dbo.ItemRequisitions",
                c => new
                    {
                        RequisitionId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.String(nullable: false, maxLength: 128),
                        RequisitionDate = c.DateTime(nullable: false, storeType: "date"),
                        ApproveStatus = c.String(maxLength: 10),
                        FormStatus = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        ApproveDate = c.DateTime(storeType: "date"),
                        ReceiveDate = c.DateTime(storeType: "date"),
                        Remark = c.String(maxLength: 300, unicode: false),
                    })
                .PrimaryKey(t => t.RequisitionId)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.MeasurementUnit",
                c => new
                    {
                        UnitId = c.Int(nullable: false, identity: true),
                        UnitName = c.String(nullable: false, maxLength: 30, unicode: false),
                        UnitQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UnitId);
            
            CreateTable(
                "dbo.SupplierItem",
                c => new
                    {
                        SupplierItemId = c.Int(nullable: false, identity: true),
                        SupplierId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        UnitId = c.Int(nullable: false),
                        TenderPrice = c.Decimal(nullable: false, precision: 8, scale: 2),
                        Status = c.String(maxLength: 20, unicode: false),
                        Remark = c.String(maxLength: 300, unicode: false),
                        Priority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierItemId)
                .ForeignKey("dbo.Supplier", t => t.SupplierId)
                .ForeignKey("dbo.MeasurementUnit", t => t.UnitId)
                .ForeignKey("dbo.Item", t => t.ItemId)
                .Index(t => t.SupplierId)
                .Index(t => t.ItemId)
                .Index(t => t.UnitId);
            
            CreateTable(
                "dbo.PurchaseOrderDetails",
                c => new
                    {
                        PurchaseOrderDetailsId = c.Int(nullable: false, identity: true),
                        SupplierItemId = c.Int(nullable: false),
                        PurchaseItemQuantity = c.Int(nullable: false),
                        QuantityDelivered = c.Int(),
                        PurchaseOrderId = c.Int(nullable: false),
                        Status = c.String(maxLength: 50, unicode: false),
                        Remark = c.String(maxLength: 300, unicode: false),
                    })
                .PrimaryKey(t => t.PurchaseOrderDetailsId)
                .ForeignKey("dbo.PurchaseOrder", t => t.PurchaseOrderId)
                .ForeignKey("dbo.SupplierItem", t => t.SupplierItemId)
                .Index(t => t.SupplierItemId)
                .Index(t => t.PurchaseOrderId);
            
            CreateTable(
                "dbo.PurchaseOrder",
                c => new
                    {
                        PurchaseOrderId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.String(maxLength: 128),
                        PurchaseOrderDate = c.DateTime(nullable: false, storeType: "date"),
                        ExpectedDate = c.DateTime(storeType: "date"),
                        Status = c.String(maxLength: 10, unicode: false),
                        Remark = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.PurchaseOrderId)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(nullable: false, maxLength: 50, unicode: false),
                        ContactName = c.String(nullable: false, maxLength: 50, unicode: false),
                        PhoneNo = c.String(maxLength: 15, unicode: false),
                        FaxNo = c.String(maxLength: 15, unicode: false),
                        Address = c.String(maxLength: 100, unicode: false),
                        GstRegistrationNo = c.String(maxLength: 30, unicode: false),
                        Status = c.String(maxLength: 20, unicode: false),
                        Remark = c.String(maxLength: 300, unicode: false),
                        Email = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.SupplierId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Disbursement", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.SupplierItem", "ItemId", "dbo.Item");
            DropForeignKey("dbo.SupplierItem", "UnitId", "dbo.MeasurementUnit");
            DropForeignKey("dbo.SupplierItem", "SupplierId", "dbo.Supplier");
            DropForeignKey("dbo.PurchaseOrderDetails", "SupplierItemId", "dbo.SupplierItem");
            DropForeignKey("dbo.PurchaseOrderDetails", "PurchaseOrderId", "dbo.PurchaseOrder");
            DropForeignKey("dbo.PurchaseOrder", "EmployeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Item", "UnitId", "dbo.MeasurementUnit");
            DropForeignKey("dbo.ItemRequisitionDetail", "ItemId", "dbo.Item");
            DropForeignKey("dbo.ItemRequisitionDetail", "RequisitionId", "dbo.ItemRequisitions");
            DropForeignKey("dbo.ItemRequisitions", "EmployeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Item", "LocationId", "dbo.ItemLocation");
            DropForeignKey("dbo.ItemAdjustment", "ItemId", "dbo.Item");
            DropForeignKey("dbo.ItemAdjustment", "EmployeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Disbursement", "ItemId", "dbo.Item");
            DropForeignKey("dbo.Item", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Department", "CollectionPointId", "dbo.CollectionPoint");
            DropForeignKey("dbo.DelegationRecord", "EmployeeId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.PurchaseOrder", new[] { "EmployeeId" });
            DropIndex("dbo.PurchaseOrderDetails", new[] { "PurchaseOrderId" });
            DropIndex("dbo.PurchaseOrderDetails", new[] { "SupplierItemId" });
            DropIndex("dbo.SupplierItem", new[] { "UnitId" });
            DropIndex("dbo.SupplierItem", new[] { "ItemId" });
            DropIndex("dbo.SupplierItem", new[] { "SupplierId" });
            DropIndex("dbo.ItemRequisitions", new[] { "EmployeeId" });
            DropIndex("dbo.ItemRequisitionDetail", new[] { "RequisitionId" });
            DropIndex("dbo.ItemRequisitionDetail", new[] { "ItemId" });
            DropIndex("dbo.ItemAdjustment", new[] { "EmployeeId" });
            DropIndex("dbo.ItemAdjustment", new[] { "ItemId" });
            DropIndex("dbo.Item", new[] { "LocationId" });
            DropIndex("dbo.Item", new[] { "UnitId" });
            DropIndex("dbo.Item", new[] { "CategoryId" });
            DropIndex("dbo.Disbursement", new[] { "DepartmentId" });
            DropIndex("dbo.Disbursement", new[] { "ItemId" });
            DropIndex("dbo.Department", new[] { "CollectionPointId" });
            DropIndex("dbo.DelegationRecord", new[] { "EmployeeId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "DepartmentId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Supplier");
            DropTable("dbo.PurchaseOrder");
            DropTable("dbo.PurchaseOrderDetails");
            DropTable("dbo.SupplierItem");
            DropTable("dbo.MeasurementUnit");
            DropTable("dbo.ItemRequisitions");
            DropTable("dbo.ItemRequisitionDetail");
            DropTable("dbo.ItemLocation");
            DropTable("dbo.ItemAdjustment");
            DropTable("dbo.Category");
            DropTable("dbo.Item");
            DropTable("dbo.Disbursement");
            DropTable("dbo.CollectionPoint");
            DropTable("dbo.Department");
            DropTable("dbo.DelegationRecord");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
        }
    }
}
