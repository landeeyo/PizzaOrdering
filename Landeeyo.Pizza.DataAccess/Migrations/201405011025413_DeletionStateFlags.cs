namespace Landeeyo.Pizza.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletionStateFlags : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pizza", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Restaurant", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.User", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "IsActive");
            DropColumn("dbo.Restaurant", "IsActive");
            DropColumn("dbo.Pizza", "IsActive");
        }
    }
}
