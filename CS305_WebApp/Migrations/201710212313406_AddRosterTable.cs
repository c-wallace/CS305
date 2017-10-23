namespace CS305_WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRosterTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RosterModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Lastname = c.String(),
                        Firstname = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RosterModels");
        }
    }
}
