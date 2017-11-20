namespace CS305_WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class keywordsTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.KeywordsProgramModels", newName: "ProgramModelKeywords");
            DropPrimaryKey("dbo.ProgramModelKeywords");
            AddPrimaryKey("dbo.ProgramModelKeywords", new[] { "ProgramModel_ID", "Keywords_ID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProgramModelKeywords");
            AddPrimaryKey("dbo.ProgramModelKeywords", new[] { "Keywords_ID", "ProgramModel_ID" });
            RenameTable(name: "dbo.ProgramModelKeywords", newName: "KeywordsProgramModels");
        }
    }
}
