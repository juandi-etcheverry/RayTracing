namespace RepositoryInDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PositionedModels", name: "Scene_Id", newName: "SceneId");
            RenameIndex(table: "dbo.PositionedModels", name: "IX_Scene_Id", newName: "IX_SceneId");
            AlterColumn("dbo.Clients", "RegistrationDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Models", "CreatedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Models", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Clients", "RegistrationDate", c => c.DateTime(nullable: false));
            RenameIndex(table: "dbo.PositionedModels", name: "IX_SceneId", newName: "IX_Scene_Id");
            RenameColumn(table: "dbo.PositionedModels", name: "SceneId", newName: "Scene_Id");
        }
    }
}
