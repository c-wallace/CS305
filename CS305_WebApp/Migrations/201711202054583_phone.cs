namespace CS305_WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phone : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProgramModels", "number", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProgramModels", "number", c => c.Int(nullable: false));
        }
    }
}
