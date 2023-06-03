namespace RepositoryInDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PositionedModels", "Scene_Id", "dbo.Scenes");
            DropIndex("dbo.PositionedModels", new[] { "Scene_Id" });
            AlterColumn("dbo.PositionedModels", "Scene_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.PositionedModels", "Scene_Id");
            AddForeignKey("dbo.PositionedModels", "Scene_Id", "dbo.Scenes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PositionedModels", "Scene_Id", "dbo.Scenes");
            DropIndex("dbo.PositionedModels", new[] { "Scene_Id" });
            AlterColumn("dbo.PositionedModels", "Scene_Id", c => c.Int());
            CreateIndex("dbo.PositionedModels", "Scene_Id");
            AddForeignKey("dbo.PositionedModels", "Scene_Id", "dbo.Scenes", "Id");
        }
    }
}
