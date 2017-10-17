namespace Mikes_Bikes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bikes",
                c => new
                    {
                        BikeID = c.String(nullable: false, maxLength: 128),
                        BikeName = c.String(),
                        BikeColor = c.String(),
                        BikeMfctr = c.String(),
                        BikeType = c.String(),
                        BikePrice = c.Double(nullable: false),
                        BikeDescEN = c.String(),
                        BikeDescFR = c.String(),
                        BikeSaleAmt = c.Double(nullable: false),
                        BikeDisplayed = c.Boolean(nullable: false),
                        BikeStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BikeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bikes");
        }
    }
}
