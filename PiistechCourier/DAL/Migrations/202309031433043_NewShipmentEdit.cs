namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewShipmentEdit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shipments", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Shipments", "TrackingToken", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shipments", "TrackingToken");
            DropColumn("dbo.Shipments", "CreatedAt");
        }
    }
}
