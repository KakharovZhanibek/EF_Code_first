namespace NorthWindDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Title = c.String(),
                        TitleOfCourtesy = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        PostalCode = c.String(),
                        HomePhone = c.String(),
                        Extension = c.String(),
                        Photo = c.Binary(),
                        Notes = c.String(),
                        ReportsTo = c.Int(),
                        PhotoPath = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Employees", t => t.ReportsTo)
                .Index(t => t.ReportsTo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "ReportsTo", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "ReportsTo" });
            DropTable("dbo.Employees");
        }
    }
}
