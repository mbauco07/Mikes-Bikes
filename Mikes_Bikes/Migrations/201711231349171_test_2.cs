namespace Mikes_Bikes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bikes", "BikeName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bikes", "BikeName", c => c.String());
        }
    }
}
