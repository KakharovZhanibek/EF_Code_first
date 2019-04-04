namespace NorthWindDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_31 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Photo", c => c.Binary(storeType: "image"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Photo", c => c.Binary());
        }
    }
}
