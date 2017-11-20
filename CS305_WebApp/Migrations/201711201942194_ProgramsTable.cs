namespace CS305_WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProgramsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProgramModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        address = c.String(),
                        number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Keywords",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        keyword = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.KeywordsProgramModels",
                c => new
                    {
                        Keywords_ID = c.Int(nullable: false),
                        ProgramModel_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Keywords_ID, t.ProgramModel_ID })
                .ForeignKey("dbo.Keywords", t => t.Keywords_ID, cascadeDelete: true)
                .ForeignKey("dbo.ProgramModels", t => t.ProgramModel_ID, cascadeDelete: true)
                .Index(t => t.Keywords_ID)
                .Index(t => t.ProgramModel_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KeywordsProgramModels", "ProgramModel_ID", "dbo.ProgramModels");
            DropForeignKey("dbo.KeywordsProgramModels", "Keywords_ID", "dbo.Keywords");
            DropIndex("dbo.KeywordsProgramModels", new[] { "ProgramModel_ID" });
            DropIndex("dbo.KeywordsProgramModels", new[] { "Keywords_ID" });
            DropTable("dbo.KeywordsProgramModels");
            DropTable("dbo.Keywords");
            DropTable("dbo.ProgramModels");
        }
    }
}
