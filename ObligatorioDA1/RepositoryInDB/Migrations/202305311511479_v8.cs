namespace RepositoryInDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v8 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Models", new[] { "Scene_Id" });
            CreateTable(
                "dbo.PositionedModels",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Scene_Id = c.Int(),
                        CoordinateX = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CoordinateY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CoordinateZ = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Models", t => t.Id)
                .ForeignKey("dbo.Scenes", t => t.Scene_Id)
                .Index(t => t.Id)
                .Index(t => t.Scene_Id);
            
            DropColumn("dbo.Models", "CoordinateX");
            DropColumn("dbo.Models", "CoordinateY");
            DropColumn("dbo.Models", "CoordinateZ");
            DropColumn("dbo.Models", "Discriminator");
            DropColumn("dbo.Models", "Scene_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Models", "Scene_Id", c => c.Int());
            AddColumn("dbo.Models", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Models", "CoordinateZ", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Models", "CoordinateY", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Models", "CoordinateX", c => c.Decimal(precision: 18, scale: 2));
            DropForeignKey("dbo.PositionedModels", "Id", "dbo.Models");
            DropIndex("dbo.PositionedModels", new[] { "Scene_Id" });
            DropIndex("dbo.PositionedModels", new[] { "Id" });
            DropTable("dbo.PositionedModels");
            CreateIndex("dbo.Models", "Scene_Id");
        }
    }
}
