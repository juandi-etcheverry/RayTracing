namespace RepositoryInDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shapes", "SceneName", "dbo.Clients");
            DropIndex("dbo.Shapes", new[] { "SceneName" });
            RenameColumn(table: "dbo.Shapes", name: "SceneName", newName: "Client_Name");
            AddColumn("dbo.Shapes", "ShapeName", c => c.String());
            AlterColumn("dbo.Shapes", "Client_Name", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Shapes", "Client_Name");
            AddForeignKey("dbo.Shapes", "Client_Name", "dbo.Clients", "SceneName", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shapes", "Client_Name", "dbo.Clients");
            DropIndex("dbo.Shapes", new[] { "Client_Name" });
            AlterColumn("dbo.Shapes", "Client_Name", c => c.String(maxLength: 128));
            DropColumn("dbo.Shapes", "ShapeName");
            RenameColumn(table: "dbo.Shapes", name: "Client_Name", newName: "SceneName");
            CreateIndex("dbo.Shapes", "SceneName");
            AddForeignKey("dbo.Shapes", "SceneName", "dbo.Clients", "SceneName");
        }
    }
}
