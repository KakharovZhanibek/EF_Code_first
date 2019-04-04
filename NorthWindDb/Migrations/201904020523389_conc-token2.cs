namespace NorthWindDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conctoken2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderDetails", "RowVersion", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetails", "RowVersion", c => c.Binary());
        }
    }
}
