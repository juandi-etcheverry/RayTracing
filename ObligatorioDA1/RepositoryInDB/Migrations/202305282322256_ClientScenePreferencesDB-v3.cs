namespace RepositoryInDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientScenePreferencesDBv3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientScenePreferences", "FoVDefault", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientScenePreferences", "FoVDefault");
        }
    }
}
