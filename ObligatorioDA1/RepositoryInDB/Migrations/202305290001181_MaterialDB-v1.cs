namespace RepositoryInDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaterialDBv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        OwnerName = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 128),
                        ColorX = c.Int(nullable: false),
                        ColorY = c.Int(nullable: false),
                        ColorZ = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OwnerName, t.Name });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Materials");
        }
    }
}
