namespace Mikes_Bikes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRatingPRimaryKey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        DetailID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        BikeID = c.String(maxLength: 128),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Order_OrderID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.DetailID)
                .ForeignKey("dbo.Bikes", t => t.BikeID)
                .ForeignKey("dbo.Orders", t => t.Order_OrderID)
                .Index(t => t.BikeID)
                .Index(t => t.Order_OrderID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.String(nullable: false, maxLength: 128),
                        CustomerID = c.Int(nullable: false),
                        DetailID = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        OrderPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Details", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Details", "BikeID", "dbo.Bikes");
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.Details", new[] { "Order_OrderID" });
            DropIndex("dbo.Details", new[] { "BikeID" });
            DropTable("dbo.Orders");
            DropTable("dbo.Details");
        }
    }
}
