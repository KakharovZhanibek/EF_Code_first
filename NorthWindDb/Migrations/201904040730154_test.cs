namespace NorthWindDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                        Description = c.String(),
                        Picture = c.Binary(),
                        image = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.CustomerDemographics",
                c => new
                    {
                        CustomerTypeId = c.String(nullable: false, maxLength: 128),
                        CustomerDesc = c.String(),
                    })
                .PrimaryKey(t => t.CustomerTypeId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        CompanyName = c.String(nullable: false),
                        ContactName = c.String(),
                        ContactTitle = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Territories",
                c => new
                    {
                        TerritoryId = c.String(nullable: false, maxLength: 128),
                        TerritoryDescription = c.String(nullable: false),
                        RegionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TerritoryId)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        RegionId = c.Int(nullable: false, identity: true),
                        RegionDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RegionId);
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        ShipperId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ShipperId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        ContactName = c.String(),
                        ContactTitle = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        HomePage = c.String(),
                    })
                .PrimaryKey(t => t.SupplierId);
            
            CreateTable(
                "dbo.CustomerCustomerDemo",
                c => new
                    {
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        CustomerTypeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.CustomerTypeId })
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.CustomerDemographics", t => t.CustomerTypeId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.CustomerTypeId);
            
            CreateTable(
                "dbo.EmployeeTerritories",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        TerritoryId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.TerritoryId })
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Territories", t => t.TerritoryId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.TerritoryId);
            
            AlterColumn("dbo.Orders", "CustomerId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false));
            CreateIndex("dbo.Products", "SupplierId");
            CreateIndex("dbo.Products", "CategoryId");
            CreateIndex("dbo.Orders", "CustomerId");
            CreateIndex("dbo.Orders", "EmployeeId");
            CreateIndex("dbo.Orders", "ShipVia");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.Customers", "CustomerId");
            AddForeignKey("dbo.Orders", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "ShipVia", "dbo.Shippers", "ShipperId", cascadeDelete: true);
            AddForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers", "SupplierId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Orders", "ShipVia", "dbo.Shippers");
            DropForeignKey("dbo.Territories", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.EmployeeTerritories", "TerritoryId", "dbo.Territories");
            DropForeignKey("dbo.EmployeeTerritories", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Orders", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerCustomerDemo", "CustomerTypeId", "dbo.CustomerDemographics");
            DropForeignKey("dbo.CustomerCustomerDemo", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.EmployeeTerritories", new[] { "TerritoryId" });
            DropIndex("dbo.EmployeeTerritories", new[] { "EmployeeId" });
            DropIndex("dbo.CustomerCustomerDemo", new[] { "CustomerTypeId" });
            DropIndex("dbo.CustomerCustomerDemo", new[] { "CustomerId" });
            DropIndex("dbo.Territories", new[] { "RegionId" });
            DropIndex("dbo.Orders", new[] { "ShipVia" });
            DropIndex("dbo.Orders", new[] { "EmployeeId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "SupplierId" });
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
            AlterColumn("dbo.Employees", "LastName", c => c.String());
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            AlterColumn("dbo.Orders", "CustomerId", c => c.String());
            DropTable("dbo.EmployeeTerritories");
            DropTable("dbo.CustomerCustomerDemo");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Shippers");
            DropTable("dbo.Regions");
            DropTable("dbo.Territories");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerDemographics");
            DropTable("dbo.Categories");
        }
    }
}
