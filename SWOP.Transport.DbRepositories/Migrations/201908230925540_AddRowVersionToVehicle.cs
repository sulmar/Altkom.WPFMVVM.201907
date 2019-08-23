namespace SWOP.Transport.DbRepositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRowVersionToVehicle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "RowVersion");
        }
    }
}
