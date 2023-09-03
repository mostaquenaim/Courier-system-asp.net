namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewShipmentEdit1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Shipments", "TrackingToken", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shipments", "TrackingToken", c => c.String());
        }
    }
}
