namespace CS305_WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class needed : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProgramModelKeywords", newName: "KeywordsProgramModels");
            DropPrimaryKey("dbo.KeywordsProgramModels");
            AddPrimaryKey("dbo.KeywordsProgramModels", new[] { "Keywords_ID", "ProgramModel_ID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.KeywordsProgramModels");
            AddPrimaryKey("dbo.KeywordsProgramModels", new[] { "ProgramModel_ID", "Keywords_ID" });
            RenameTable(name: "dbo.KeywordsProgramModels", newName: "ProgramModelKeywords");
        }
    }
}
