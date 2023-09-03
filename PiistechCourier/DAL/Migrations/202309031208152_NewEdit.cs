namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewEdit : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Tokens", "AdminId");
            AddForeignKey("dbo.Tokens", "AdminId", "dbo.Admins", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "AdminId", "dbo.Admins");
            DropIndex("dbo.Tokens", new[] { "AdminId" });
        }
    }
}
