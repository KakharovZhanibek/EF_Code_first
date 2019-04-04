namespace NorthWindDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conctoken : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "RowVersion", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "RowVersion");
        }
    }
}
