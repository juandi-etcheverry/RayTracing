namespace RepositoryInDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        RegistrationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Password = c.String(),
                        ClientScenePreferences_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.ClientScenePreferences", t => t.ClientScenePreferences_Id)
                .Index(t => t.ClientScenePreferences_Id);
            
            CreateTable(
                "dbo.ClientScenePreferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LookFromDefaultX = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LookFromDefaultY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LookFromDefaultZ = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LookAtDefaultX = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LookAtDefaultY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LookAtDefaultZ = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FoVDefault = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RenderingTimeInSeconds = c.Int(nullable: false),
                        RenderDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        RenderWindow = c.String(),
                        SceneName = c.String(),
                        NumberOfModels = c.Int(nullable: false),
                        Client_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Name)
                .Index(t => t.Client_Name);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaterialName = c.String(),
                        ColorX = c.Int(nullable: false),
                        ColorY = c.Int(nullable: false),
                        ColorZ = c.Int(nullable: false),
                        Blur = c.Decimal(precision: 18, scale: 2),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Client_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Name)
                .Index(t => t.Client_Name);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WantPreview = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModelName = c.String(),
                        Client_Name = c.String(maxLength: 128),
                        Material_Id = c.Int(),
                        Shape_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Name)
                .ForeignKey("dbo.Materials", t => t.Material_Id)
                .ForeignKey("dbo.Shapes", t => t.Shape_Id)
                .Index(t => t.Client_Name)
                .Index(t => t.Material_Id)
                .Index(t => t.Shape_Id);
            
            CreateTable(
                "dbo.Shapes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShapeName = c.String(),
                        Client_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Name)
                .Index(t => t.Client_Name);
            
            CreateTable(
                "dbo.Scenes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegistrationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastRenderDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SceneName = c.String(),
                        Client_Name = c.String(maxLength: 128),
                        ClientScenePreferences_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Name)
                .ForeignKey("dbo.ClientScenePreferences", t => t.ClientScenePreferences_Id)
                .Index(t => t.Client_Name)
                .Index(t => t.ClientScenePreferences_Id);
            
            CreateTable(
                "dbo.PositionedModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CoordinateX = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CoordinateY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CoordinateZ = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Model_Id = c.Int(),
                        Scene_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Models", t => t.Model_Id)
                .ForeignKey("dbo.Scenes", t => t.Scene_Id, cascadeDelete: true)
                .Index(t => t.Model_Id)
                .Index(t => t.Scene_Id);
            
            CreateTable(
                "dbo.Spheres",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Radius = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shapes", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Spheres", "Id", "dbo.Shapes");
            DropForeignKey("dbo.PositionedModels", "Scene_Id", "dbo.Scenes");
            DropForeignKey("dbo.PositionedModels", "Model_Id", "dbo.Models");
            DropForeignKey("dbo.Scenes", "ClientScenePreferences_Id", "dbo.ClientScenePreferences");
            DropForeignKey("dbo.Scenes", "Client_Name", "dbo.Clients");
            DropForeignKey("dbo.Models", "Shape_Id", "dbo.Shapes");
            DropForeignKey("dbo.Shapes", "Client_Name", "dbo.Clients");
            DropForeignKey("dbo.Models", "Material_Id", "dbo.Materials");
            DropForeignKey("dbo.Models", "Client_Name", "dbo.Clients");
            DropForeignKey("dbo.Materials", "Client_Name", "dbo.Clients");
            DropForeignKey("dbo.Logs", "Client_Name", "dbo.Clients");
            DropForeignKey("dbo.Clients", "ClientScenePreferences_Id", "dbo.ClientScenePreferences");
            DropIndex("dbo.Spheres", new[] { "Id" });
            DropIndex("dbo.PositionedModels", new[] { "Scene_Id" });
            DropIndex("dbo.PositionedModels", new[] { "Model_Id" });
            DropIndex("dbo.Scenes", new[] { "ClientScenePreferences_Id" });
            DropIndex("dbo.Scenes", new[] { "Client_Name" });
            DropIndex("dbo.Shapes", new[] { "Client_Name" });
            DropIndex("dbo.Models", new[] { "Shape_Id" });
            DropIndex("dbo.Models", new[] { "Material_Id" });
            DropIndex("dbo.Models", new[] { "Client_Name" });
            DropIndex("dbo.Materials", new[] { "Client_Name" });
            DropIndex("dbo.Logs", new[] { "Client_Name" });
            DropIndex("dbo.Clients", new[] { "ClientScenePreferences_Id" });
            DropTable("dbo.Spheres");
            DropTable("dbo.PositionedModels");
            DropTable("dbo.Scenes");
            DropTable("dbo.Shapes");
            DropTable("dbo.Models");
            DropTable("dbo.Materials");
            DropTable("dbo.Logs");
            DropTable("dbo.ClientScenePreferences");
            DropTable("dbo.Clients");
        }
    }
}
