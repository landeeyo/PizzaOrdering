namespace Landeeyo.Pizza.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueLogin : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.User");
            AddPrimaryKey("dbo.User", new[] { "UserID", "Login" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.User");
            AddPrimaryKey("dbo.User", "UserID");
        }
    }
}
