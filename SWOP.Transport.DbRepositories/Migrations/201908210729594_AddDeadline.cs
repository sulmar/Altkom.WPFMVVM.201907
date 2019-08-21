namespace SWOP.Transport.DbRepositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeadline : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deadlines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Type = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Vehicle_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Id)
                .Index(t => t.Vehicle_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deadlines", "Vehicle_Id", "dbo.Vehicles");
            DropIndex("dbo.Deadlines", new[] { "Vehicle_Id" });
            DropTable("dbo.Deadlines");
        }
    }
}
