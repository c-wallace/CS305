namespace CS305_WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class needed1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.KeywordsProgramModels", "Keywords_ID", "dbo.Keywords");
            DropForeignKey("dbo.KeywordsProgramModels", "ProgramModel_ID", "dbo.ProgramModels");
            DropIndex("dbo.KeywordsProgramModels", new[] { "Keywords_ID" });
            DropIndex("dbo.KeywordsProgramModels", new[] { "ProgramModel_ID" });
            DropTable("dbo.Keywords");
            DropTable("dbo.KeywordsProgramModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.KeywordsProgramModels",
                c => new
                    {
                        Keywords_ID = c.Int(nullable: false),
                        ProgramModel_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Keywords_ID, t.ProgramModel_ID });
            
            CreateTable(
                "dbo.Keywords",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        keyword = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.KeywordsProgramModels", "ProgramModel_ID");
            CreateIndex("dbo.KeywordsProgramModels", "Keywords_ID");
            AddForeignKey("dbo.KeywordsProgramModels", "ProgramModel_ID", "dbo.ProgramModels", "ID", cascadeDelete: true);
            AddForeignKey("dbo.KeywordsProgramModels", "Keywords_ID", "dbo.Keywords", "ID", cascadeDelete: true);
        }
    }
}
