namespace RepositoryInDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Logs", "RenderWindow", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Logs", "RenderWindow", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
