namespace Mikes_Bikes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_requires : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bikes", "BikeColor", c => c.String(nullable: false));
            AlterColumn("dbo.Bikes", "BikeMfctr", c => c.String(nullable: false));
            AlterColumn("dbo.Bikes", "BikeType", c => c.String(nullable: false));
            AlterColumn("dbo.Bikes", "BikeDescEN", c => c.String(nullable: false));
            AlterColumn("dbo.Bikes", "BikeDescFR", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bikes", "BikeDescFR", c => c.String());
            AlterColumn("dbo.Bikes", "BikeDescEN", c => c.String());
            AlterColumn("dbo.Bikes", "BikeType", c => c.String());
            AlterColumn("dbo.Bikes", "BikeMfctr", c => c.String());
            AlterColumn("dbo.Bikes", "BikeColor", c => c.String());
        }
    }
}
