namespace Landeeyo.Pizza.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSoftDeleteToSomeEntities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pizza", "CreateDate", c => c.DateTime());
            AddColumn("dbo.Pizza", "DeactivationDate", c => c.DateTime());
            AddColumn("dbo.Restaurant", "CreateDate", c => c.DateTime());
            AddColumn("dbo.Restaurant", "DeactivationDate", c => c.DateTime());
            DropColumn("dbo.Pizza", "IsActive");
            DropColumn("dbo.Restaurant", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurant", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pizza", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.Restaurant", "DeactivationDate");
            DropColumn("dbo.Restaurant", "CreateDate");
            DropColumn("dbo.Pizza", "DeactivationDate");
            DropColumn("dbo.Pizza", "CreateDate");
        }
    }
}
