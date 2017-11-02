namespace Mikes_Bikes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newdb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "CustFName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "CustLName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "CustEmail", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "CustPhone", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "CustPwd", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "CustPwd", c => c.String());
            AlterColumn("dbo.Customers", "CustPhone", c => c.String());
            AlterColumn("dbo.Customers", "CustEmail", c => c.String());
            AlterColumn("dbo.Customers", "CustLName", c => c.String());
            AlterColumn("dbo.Customers", "CustFName", c => c.String());
        }
    }
}
