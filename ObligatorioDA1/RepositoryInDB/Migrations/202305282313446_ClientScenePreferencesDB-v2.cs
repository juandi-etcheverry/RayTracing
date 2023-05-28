namespace RepositoryInDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientScenePreferencesDBv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientScenePreferences", "LookFromDefaultX", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ClientScenePreferences", "LookFromDefaultY", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ClientScenePreferences", "LookFromDefaultZ", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ClientScenePreferences", "LookAtDefaultX", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ClientScenePreferences", "LookAtDefaultY", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ClientScenePreferences", "LookAtDefaultZ", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientScenePreferences", "LookAtDefaultZ");
            DropColumn("dbo.ClientScenePreferences", "LookAtDefaultY");
            DropColumn("dbo.ClientScenePreferences", "LookAtDefaultX");
            DropColumn("dbo.ClientScenePreferences", "LookFromDefaultZ");
            DropColumn("dbo.ClientScenePreferences", "LookFromDefaultY");
            DropColumn("dbo.ClientScenePreferences", "LookFromDefaultX");
        }
    }
}
