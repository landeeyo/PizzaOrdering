namespace Landeeyo.Pizza.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeysOnUserModelModified : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.User", "Login", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.User", "Login");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.User", "Login", c => c.String(nullable: false, maxLength: 25));
            AddPrimaryKey("dbo.User", new[] { "UserID", "Login" });
        }
    }
}
