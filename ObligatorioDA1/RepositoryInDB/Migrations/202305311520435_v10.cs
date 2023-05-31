namespace RepositoryInDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v10 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Models", name: "Name", newName: "Client_Name");
            RenameIndex(table: "dbo.Models", name: "IX_Name", newName: "IX_Client_Name");
            AddColumn("dbo.Models", "ModelName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Models", "ModelName");
            RenameIndex(table: "dbo.Models", name: "IX_Client_Name", newName: "IX_Name");
            RenameColumn(table: "dbo.Models", name: "Client_Name", newName: "Name");
        }
    }
}
