namespace Strado.InVento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InventoryModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartsId = c.Int(nullable: false),
                        QtyInStock = c.Int(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parts", t => t.PartsId, cascadeDelete: true)
                .Index(t => t.PartsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventories", "PartsId", "dbo.Parts");
            DropIndex("dbo.Inventories", new[] { "PartsId" });
            DropTable("dbo.Inventories");
        }
    }
}
