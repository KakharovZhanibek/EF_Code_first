namespace NorthWindDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductName", c => c.String());
            AddColumn("dbo.Products", "SupplierId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "QuantityPerUnit", c => c.String());
            AddColumn("dbo.Products", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "UnitsInStock", c => c.Short(nullable: false));
            AddColumn("dbo.Products", "UnitsOnOrder", c => c.Short(nullable: false));
            AddColumn("dbo.Products", "ReorderLevel", c => c.Short(nullable: false));
            AddColumn("dbo.Products", "Discontinued", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Discontinued");
            DropColumn("dbo.Products", "ReorderLevel");
            DropColumn("dbo.Products", "UnitsOnOrder");
            DropColumn("dbo.Products", "UnitsInStock");
            DropColumn("dbo.Products", "UnitPrice");
            DropColumn("dbo.Products", "QuantityPerUnit");
            DropColumn("dbo.Products", "CategoryId");
            DropColumn("dbo.Products", "SupplierId");
            DropColumn("dbo.Products", "ProductName");
        }
    }
}
