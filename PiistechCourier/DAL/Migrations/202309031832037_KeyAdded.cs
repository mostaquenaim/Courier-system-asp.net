namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeyAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Address", c => c.String());
        }
    }
}
