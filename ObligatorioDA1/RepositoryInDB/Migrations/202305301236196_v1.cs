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
                        RegistrationDate = c.DateTime(nullable: false),
                        Password = c.String(),
                        ClientScenePreferences_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.ClientScenePreferences", t => t.ClientScenePreferences_Id, cascadeDelete: true)
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
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaterialName = c.String(),
                        ColorX = c.Int(nullable: false),
                        ColorY = c.Int(nullable: false),
                        ColorZ = c.Int(nullable: false),
                        Client_Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Name, cascadeDelete: true)
                .Index(t => t.Client_Name);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WantPreview = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        Name = c.String(nullable: false, maxLength: 128),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Material_Id = c.Int(nullable: false),
                        Shape_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Name, cascadeDelete: false)
                .ForeignKey("dbo.Materials", t => t.Material_Id, cascadeDelete: false)
                .ForeignKey("dbo.Shapes", t => t.Shape_Id, cascadeDelete: false)
                .Index(t => t.Name)
                .Index(t => t.Material_Id)
                .Index(t => t.Shape_Id);
            
            CreateTable(
                "dbo.Shapes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        Radius = c.Double(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Name)
                .Index(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Models", "Shape_Id", "dbo.Shapes");
            DropForeignKey("dbo.Shapes", "ShapeName", "dbo.Clients");
            DropForeignKey("dbo.Models", "Material_Id", "dbo.Materials");
            DropForeignKey("dbo.Models", "ShapeName", "dbo.Clients");
            DropForeignKey("dbo.Materials", "Client_Name", "dbo.Clients");
            DropForeignKey("dbo.Clients", "ClientScenePreferences_Id", "dbo.ClientScenePreferences");
            DropIndex("dbo.Shapes", new[] { "ShapeName" });
            DropIndex("dbo.Models", new[] { "Shape_Id" });
            DropIndex("dbo.Models", new[] { "Material_Id" });
            DropIndex("dbo.Models", new[] { "ShapeName" });
            DropIndex("dbo.Materials", new[] { "Client_Name" });
            DropIndex("dbo.Clients", new[] { "ClientScenePreferences_Id" });
            DropTable("dbo.Shapes");
            DropTable("dbo.Models");
            DropTable("dbo.Materials");
            DropTable("dbo.ClientScenePreferences");
            DropTable("dbo.Clients");
        }
    }
}
