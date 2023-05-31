namespace RepositoryInDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "ClientScenePreferences_Id", "dbo.ClientScenePreferences");
            DropForeignKey("dbo.Materials", "Client_Name", "dbo.Clients");
            DropForeignKey("dbo.Shapes", "Client_Name", "dbo.Clients");
            DropIndex("dbo.Clients", new[] { "ClientScenePreferences_Id" });
            DropIndex("dbo.Materials", new[] { "Client_Name" });
            DropIndex("dbo.Shapes", new[] { "Client_Name" });
            AlterColumn("dbo.Clients", "ClientScenePreferences_Id", c => c.Int());
            AlterColumn("dbo.Materials", "Client_Name", c => c.String(maxLength: 128));
            AlterColumn("dbo.Shapes", "Client_Name", c => c.String(maxLength: 128));
            CreateIndex("dbo.Clients", "ClientScenePreferences_Id");
            CreateIndex("dbo.Materials", "Client_Name");
            CreateIndex("dbo.Shapes", "Client_Name");
            AddForeignKey("dbo.Clients", "ClientScenePreferences_Id", "dbo.ClientScenePreferences", "Id");
            AddForeignKey("dbo.Materials", "Client_Name", "dbo.Clients", "Name");
            AddForeignKey("dbo.Shapes", "Client_Name", "dbo.Clients", "Name");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shapes", "Client_Name", "dbo.Clients");
            DropForeignKey("dbo.Materials", "Client_Name", "dbo.Clients");
            DropForeignKey("dbo.Clients", "ClientScenePreferences_Id", "dbo.ClientScenePreferences");
            DropIndex("dbo.Shapes", new[] { "Client_Name" });
            DropIndex("dbo.Materials", new[] { "Client_Name" });
            DropIndex("dbo.Clients", new[] { "ClientScenePreferences_Id" });
            AlterColumn("dbo.Shapes", "Client_Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Materials", "Client_Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Clients", "ClientScenePreferences_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Shapes", "Client_Name");
            CreateIndex("dbo.Materials", "Client_Name");
            CreateIndex("dbo.Clients", "ClientScenePreferences_Id");
            AddForeignKey("dbo.Shapes", "Client_Name", "dbo.Clients", "Name", cascadeDelete: true);
            AddForeignKey("dbo.Materials", "Client_Name", "dbo.Clients", "Name", cascadeDelete: true);
            AddForeignKey("dbo.Clients", "ClientScenePreferences_Id", "dbo.ClientScenePreferences", "Id", cascadeDelete: true);
        }
    }
}
