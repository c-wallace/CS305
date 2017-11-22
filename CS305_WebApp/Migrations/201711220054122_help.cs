namespace CS305_WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class help : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProgramModels", "name", c => c.String(nullable: false));
            AlterColumn("dbo.ProgramModels", "address", c => c.String(nullable: false));
            AlterColumn("dbo.ProgramModels", "number", c => c.String(nullable: false));
            AlterColumn("dbo.ProgramModels", "keyword", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProgramModels", "keyword", c => c.String());
            AlterColumn("dbo.ProgramModels", "number", c => c.String());
            AlterColumn("dbo.ProgramModels", "address", c => c.String());
            AlterColumn("dbo.ProgramModels", "name", c => c.String());
        }
    }
}
