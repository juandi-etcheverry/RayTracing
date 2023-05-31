namespace RepositoryInDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PositionedModels",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CoordinateX = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CoordinateY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CoordinateZ = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Models", t => t.Id)
                .Index(t => t.Id);
            
            DropColumn("dbo.Models", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Models", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.PositionedModels", "Id", "dbo.Models");
            DropIndex("dbo.PositionedModels", new[] { "Id" });
            DropTable("dbo.PositionedModels");
        }
    }
}
