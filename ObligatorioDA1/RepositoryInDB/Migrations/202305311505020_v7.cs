namespace RepositoryInDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PositionedModels", "Id", "dbo.Models");
            DropIndex("dbo.PositionedModels", new[] { "Id" });
            DropIndex("dbo.PositionedModels", new[] { "Scene_Id" });
            AddColumn("dbo.Models", "CoordinateX", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Models", "CoordinateY", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Models", "CoordinateZ", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Models", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Models", "Scene_Id", c => c.Int());
            CreateIndex("dbo.Models", "Scene_Id");
            DropTable("dbo.PositionedModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PositionedModels",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Scene_Id = c.Int(),
                        CoordinateX = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CoordinateY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CoordinateZ = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdPositionedModel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.Models", new[] { "Scene_Id" });
            DropColumn("dbo.Models", "Scene_Id");
            DropColumn("dbo.Models", "Discriminator");
            DropColumn("dbo.Models", "CoordinateZ");
            DropColumn("dbo.Models", "CoordinateY");
            DropColumn("dbo.Models", "CoordinateX");
            CreateIndex("dbo.PositionedModels", "Scene_Id");
            CreateIndex("dbo.PositionedModels", "Id");
            AddForeignKey("dbo.PositionedModels", "Id", "dbo.Models", "Id");
        }
    }
}
