namespace RepositoryInDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientScenePreferencesDBv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientScenePreferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Clients", "ClientScenePreferences_Id", c => c.Int());
            CreateIndex("dbo.Clients", "ClientScenePreferences_Id");
            AddForeignKey("dbo.Clients", "ClientScenePreferences_Id", "dbo.ClientScenePreferences", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "ClientScenePreferences_Id", "dbo.ClientScenePreferences");
            DropIndex("dbo.Clients", new[] { "ClientScenePreferences_Id" });
            DropColumn("dbo.Clients", "ClientScenePreferences_Id");
            DropTable("dbo.ClientScenePreferences");
        }
    }
}
