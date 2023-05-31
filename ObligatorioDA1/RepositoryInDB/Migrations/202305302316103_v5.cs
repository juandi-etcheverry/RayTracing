namespace RepositoryInDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Scenes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SceneName = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        LastModificationDate = c.DateTime(nullable: false),
                        LastRenderDate = c.DateTime(nullable: false),
                        Client_Name = c.String(nullable: false, maxLength: 128),
                        ClientScenePreferences_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Name, cascadeDelete: false)
                .ForeignKey("dbo.ClientScenePreferences", t => t.ClientScenePreferences_Id)
                .Index(t => t.Client_Name)
                .Index(t => t.ClientScenePreferences_Id);
            
            AddColumn("dbo.PositionedModels", "IdPositionedModel", c => c.Int(nullable: false));
            CreateIndex("dbo.PositionedModels", "IdPositionedModel");
            AddForeignKey("dbo.PositionedModels", "IdPositionedModel", "dbo.Scenes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PositionedModels", "IdPositionedModel", "dbo.Scenes");
            DropForeignKey("dbo.Scenes", "ClientScenePreferences_Id", "dbo.ClientScenePreferences");
            DropForeignKey("dbo.Scenes", "Client_Name", "dbo.Clients");
            DropIndex("dbo.PositionedModels", new[] { "IdPositionedModel" });
            DropIndex("dbo.Scenes", new[] { "ClientScenePreferences_Id" });
            DropIndex("dbo.Scenes", new[] { "Client_Name" });
            DropColumn("dbo.PositionedModels", "IdPositionedModel");
            DropTable("dbo.Scenes");
        }
    }
}
