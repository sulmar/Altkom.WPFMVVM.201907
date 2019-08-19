namespace SWOP.Transport.DbRepositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 32),
                        Email = c.String(maxLength: 255),
                        Phone = c.String(),
                        UserName = c.String(),
                        HashPassword = c.String(),
                        Grade = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(maxLength: 50),
                        Model = c.String(maxLength: 50),
                        PlateNumber = c.String(nullable: false, maxLength: 8),
                        IsRemoved = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Type = c.Int(nullable: false),
                        Owner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "Owner_Id", "dbo.Employees");
            DropIndex("dbo.Vehicles", new[] { "Owner_Id" });
            DropIndex("dbo.Employees", new[] { "Email" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.Employees");
        }
    }
}
