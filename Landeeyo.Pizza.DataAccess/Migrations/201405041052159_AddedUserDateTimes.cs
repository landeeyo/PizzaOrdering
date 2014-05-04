namespace Landeeyo.Pizza.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserDateTimes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "CreateDate", c => c.DateTime());
            AddColumn("dbo.User", "DeactivationDate", c => c.DateTime());
            DropColumn("dbo.User", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.User", "DeactivationDate");
            DropColumn("dbo.User", "CreateDate");
        }
    }
}
