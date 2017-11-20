namespace CS305_WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProgramModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RosterModels", "Lastname", c => c.String(nullable: false));
            AlterColumn("dbo.RosterModels", "Firstname", c => c.String(nullable: false));
            AlterColumn("dbo.RosterModels", "description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RosterModels", "description", c => c.String());
            AlterColumn("dbo.RosterModels", "Firstname", c => c.String());
            AlterColumn("dbo.RosterModels", "Lastname", c => c.String());
        }
    }
}
