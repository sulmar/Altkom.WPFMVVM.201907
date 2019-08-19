namespace SWOP.Transport.DbRepositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCellPhoneToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "CellPhone", c => c.String(maxLength: 9));
            Sql("update dbo.Employees set CellPhone = '555123321' where CellPhone is null");

        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "CellPhone");
        }
    }
}
