namespace CS305_WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class keywordcolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProgramModels", "keyword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProgramModels", "keyword");
        }
    }
}
