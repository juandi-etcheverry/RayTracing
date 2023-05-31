namespace RepositoryInDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
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
            
            DropColumn("dbo.Shapes", "Radius");
            DropColumn("dbo.Shapes", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shapes", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Shapes", "Radius", c => c.Double());
            DropForeignKey("dbo.Spheres", "Id", "dbo.Shapes");
            DropIndex("dbo.Spheres", new[] { "Id" });
            DropTable("dbo.Spheres");
        }
    }
}
