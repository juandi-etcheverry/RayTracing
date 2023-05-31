namespace RepositoryInDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Models", "Name", "dbo.Clients");
            DropForeignKey("dbo.Models", "Material_Id", "dbo.Materials");
            DropForeignKey("dbo.Models", "Shape_Id", "dbo.Shapes");
            DropForeignKey("dbo.Scenes", "Client_Name", "dbo.Clients");
            DropIndex("dbo.Models", new[] { "Name" });
            DropIndex("dbo.Models", new[] { "Material_Id" });
            DropIndex("dbo.Models", new[] { "Shape_Id" });
            DropIndex("dbo.Scenes", new[] { "Client_Name" });
            AlterColumn("dbo.Models", "Name", c => c.String(maxLength: 128));
            AlterColumn("dbo.Models", "Material_Id", c => c.Int());
            AlterColumn("dbo.Models", "Shape_Id", c => c.Int());
            AlterColumn("dbo.Scenes", "Client_Name", c => c.String(maxLength: 128));
            CreateIndex("dbo.Models", "Name");
            CreateIndex("dbo.Models", "Material_Id");
            CreateIndex("dbo.Models", "Shape_Id");
            CreateIndex("dbo.Scenes", "Client_Name");
            AddForeignKey("dbo.Models", "Name", "dbo.Clients", "Name");
            AddForeignKey("dbo.Models", "Material_Id", "dbo.Materials", "Id");
            AddForeignKey("dbo.Models", "Shape_Id", "dbo.Shapes", "Id");
            AddForeignKey("dbo.Scenes", "Client_Name", "dbo.Clients", "Name");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scenes", "Client_Name", "dbo.Clients");
            DropForeignKey("dbo.Models", "Shape_Id", "dbo.Shapes");
            DropForeignKey("dbo.Models", "Material_Id", "dbo.Materials");
            DropForeignKey("dbo.Models", "Name", "dbo.Clients");
            DropIndex("dbo.Scenes", new[] { "Client_Name" });
            DropIndex("dbo.Models", new[] { "Shape_Id" });
            DropIndex("dbo.Models", new[] { "Material_Id" });
            DropIndex("dbo.Models", new[] { "Name" });
            AlterColumn("dbo.Scenes", "Client_Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Models", "Shape_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Models", "Material_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Models", "Name", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Scenes", "Client_Name");
            CreateIndex("dbo.Models", "Shape_Id");
            CreateIndex("dbo.Models", "Material_Id");
            CreateIndex("dbo.Models", "Name");
            AddForeignKey("dbo.Scenes", "Client_Name", "dbo.Clients", "Name", cascadeDelete: true);
            AddForeignKey("dbo.Models", "Shape_Id", "dbo.Shapes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Models", "Material_Id", "dbo.Materials", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Models", "Name", "dbo.Clients", "Name", cascadeDelete: true);
        }
    }
}
