namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TokenDbfix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tokens", "AdminId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tokens", "AdminId", c => c.String(nullable: false));
        }
    }
}
