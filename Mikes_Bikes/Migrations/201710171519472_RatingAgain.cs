namespace Mikes_Bikes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RatingAgain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        BikeID = c.String(maxLength: 128),
                        Rate = c.Int(nullable: false),
                        Review = c.String(),
                    })
                .PrimaryKey(t => t.RatingID)
                .ForeignKey("dbo.Bikes", t => t.BikeID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.BikeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Ratings", "BikeID", "dbo.Bikes");
            DropIndex("dbo.Ratings", new[] { "BikeID" });
            DropIndex("dbo.Ratings", new[] { "CustomerID" });
            DropTable("dbo.Ratings");
        }
    }
}
