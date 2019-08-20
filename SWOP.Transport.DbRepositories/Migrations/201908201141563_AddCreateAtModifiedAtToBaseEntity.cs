namespace SWOP.Transport.DbRepositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreateAtModifiedAtToBaseEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "CreatedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Employees", "ModifiedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Vehicles", "ModifiedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "ModifiedAt");
            DropColumn("dbo.Employees", "ModifiedAt");
            DropColumn("dbo.Employees", "CreatedAt");
        }
    }
}
