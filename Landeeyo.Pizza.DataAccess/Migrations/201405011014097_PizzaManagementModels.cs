namespace Landeeyo.Pizza.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PizzaManagementModels : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tblUser", newName: "User");
            CreateTable(
                "dbo.Pizza",
                c => new
                    {
                        PizzaID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Price = c.Double(nullable: false),
                        RestaurantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PizzaID)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantID, cascadeDelete: true)
                .Index(t => t.RestaurantID);
            
            CreateTable(
                "dbo.Restaurant",
                c => new
                    {
                        RestaurantID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.RestaurantID);
            
            AddColumn("dbo.User", "Firstname", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.User", "Surname", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.User", "Email", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.User", "Login", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 25));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pizza", "RestaurantID", "dbo.Restaurant");
            DropIndex("dbo.Pizza", new[] { "RestaurantID" });
            AlterColumn("dbo.User", "Password", c => c.String());
            AlterColumn("dbo.User", "Login", c => c.String());
            DropColumn("dbo.User", "Email");
            DropColumn("dbo.User", "Surname");
            DropColumn("dbo.User", "Firstname");
            DropTable("dbo.Restaurant");
            DropTable("dbo.Pizza");
            RenameTable(name: "dbo.User", newName: "tblUser");
        }
    }
}
