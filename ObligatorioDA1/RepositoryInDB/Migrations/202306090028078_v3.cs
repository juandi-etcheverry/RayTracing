namespace RepositoryInDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PositionedModels", new[] { "Model_Id" });
            RenameColumn(table: "dbo.PositionedModels", name: "Model_Id", newName: "ModelId");
            AlterColumn("dbo.PositionedModels", "ModelId", c => c.Int(nullable: false));
            CreateIndex("dbo.PositionedModels", "ModelId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PositionedModels", new[] { "ModelId" });
            AlterColumn("dbo.PositionedModels", "ModelId", c => c.Int());
            RenameColumn(table: "dbo.PositionedModels", name: "ModelId", newName: "Model_Id");
            CreateIndex("dbo.PositionedModels", "Model_Id");
        }
    }
}
