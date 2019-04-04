namespace NorthWindDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "UnitPrice", c => c.Decimal(nullable: false, storeType: "money"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
