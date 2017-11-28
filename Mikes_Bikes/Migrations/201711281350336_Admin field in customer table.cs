namespace Mikes_Bikes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adminfieldincustomertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Admin", c => c.Int(nullable: false));
            AlterColumn("dbo.Bikes", "BikeName", c => c.String());
            AlterColumn("dbo.Bikes", "BikeColor", c => c.String());
            AlterColumn("dbo.Bikes", "BikeMfctr", c => c.String());
            AlterColumn("dbo.Bikes", "BikeDescEN", c => c.String());
            AlterColumn("dbo.Bikes", "BikeDescFR", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bikes", "BikeDescFR", c => c.String(nullable: false));
            AlterColumn("dbo.Bikes", "BikeDescEN", c => c.String(nullable: false));
            AlterColumn("dbo.Bikes", "BikeMfctr", c => c.String(nullable: false));
            AlterColumn("dbo.Bikes", "BikeColor", c => c.String(nullable: false));
            AlterColumn("dbo.Bikes", "BikeName", c => c.String(nullable: false));
            DropColumn("dbo.Customers", "Admin");
        }
    }
}
