namespace Landeeyo.Pizza.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Log : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        LogID = c.Int(nullable: false, identity: true),
                        OcurrenceDateTime = c.DateTime(nullable: false),
                        StackTrace = c.String(),
                        Message = c.String(),
                        Class = c.String(),
                        Source = c.String(),
                        CompleteInfo = c.String(),
                    })
                .PrimaryKey(t => t.LogID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Log");
        }
    }
}
