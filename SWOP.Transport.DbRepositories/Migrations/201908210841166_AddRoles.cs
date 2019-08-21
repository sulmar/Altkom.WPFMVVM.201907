namespace SWOP.Transport.DbRepositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleEmployees",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.Employee_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleEmployees", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.RoleEmployees", "Role_Id", "dbo.Roles");
            DropIndex("dbo.RoleEmployees", new[] { "Employee_Id" });
            DropIndex("dbo.RoleEmployees", new[] { "Role_Id" });
            DropTable("dbo.RoleEmployees");
            DropTable("dbo.Roles");
        }
    }
}
