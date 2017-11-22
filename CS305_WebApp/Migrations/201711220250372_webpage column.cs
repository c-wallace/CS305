namespace CS305_WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class webpagecolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProgramModels", "webpage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProgramModels", "webpage");
        }
    }
}
