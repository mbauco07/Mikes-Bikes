namespace Mikes_Bikes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forgot_some_requires : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bikes", "BikeImage", c => c.String());
        }
    }
}
