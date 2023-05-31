namespace RepositoryInDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PositionedModels", "IdPositionedModel", "dbo.Scenes");
            DropIndex("dbo.PositionedModels", new[] { "IdPositionedModel" });
            AddColumn("dbo.PositionedModels", "Scene_Id", c => c.Int());
            CreateIndex("dbo.PositionedModels", "Scene_Id");
            AddForeignKey("dbo.PositionedModels", "Scene_Id", "dbo.Scenes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PositionedModels", "Scene_Id", "dbo.Scenes");
            DropIndex("dbo.PositionedModels", new[] { "Scene_Id" });
            DropColumn("dbo.PositionedModels", "Scene_Id");
            CreateIndex("dbo.PositionedModels", "IdPositionedModel");
            AddForeignKey("dbo.PositionedModels", "IdPositionedModel", "dbo.Scenes", "Id", cascadeDelete: true);
        }
    }
}
