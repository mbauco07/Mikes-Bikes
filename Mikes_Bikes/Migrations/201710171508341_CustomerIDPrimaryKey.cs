namespace Mikes_Bikes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerIDPrimaryKey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        BikeID = c.String(maxLength: 128),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("dbo.Bikes", t => t.BikeID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.BikeID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustFName = c.String(),
                        CustLName = c.String(),
                        CustEmail = c.String(),
                        CustPhone = c.String(),
                        CustPwd = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Carts", "BikeID", "dbo.Bikes");
            DropIndex("dbo.Carts", new[] { "BikeID" });
            DropIndex("dbo.Carts", new[] { "CustomerID" });
            DropTable("dbo.Customers");
            DropTable("dbo.Carts");
        }
    }
}
