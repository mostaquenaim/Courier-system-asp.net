namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PhoneNo = c.String(nullable: false),
                        Address = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShipperId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        ReceiverId = c.Int(nullable: false),
                        Destination = c.String(nullable: false),
                        From = c.String(),
                        EstimatedDeliveryTime = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Receivers", t => t.ReceiverId, cascadeDelete: true)
                .ForeignKey("dbo.Shippers", t => t.ShipperId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.ShipperId)
                .Index(t => t.CustomerId)
                .Index(t => t.ReceiverId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Receivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PhoneNo = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shipments", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Shipments", "ShipperId", "dbo.Shippers");
            DropForeignKey("dbo.Shipments", "ReceiverId", "dbo.Receivers");
            DropForeignKey("dbo.Shipments", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Shipments", new[] { "StatusId" });
            DropIndex("dbo.Shipments", new[] { "ReceiverId" });
            DropIndex("dbo.Shipments", new[] { "CustomerId" });
            DropIndex("dbo.Shipments", new[] { "ShipperId" });
            DropTable("dbo.Status");
            DropTable("dbo.Shippers");
            DropTable("dbo.Receivers");
            DropTable("dbo.Shipments");
            DropTable("dbo.Customers");
            DropTable("dbo.Admins");
        }
    }
}
