namespace Strado.InVento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PartsPurchaseTableCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PartsPurchaseRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartsId = c.Int(nullable: false),
                        PurchasePrice = c.Double(nullable: false),
                        PurchaseQty = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        SuppliersId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parts", t => t.PartsId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SuppliersId, cascadeDelete: true)
                .Index(t => t.PartsId)
                .Index(t => t.SuppliersId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PartsPurchaseRecords", "SuppliersId", "dbo.Suppliers");
            DropForeignKey("dbo.PartsPurchaseRecords", "PartsId", "dbo.Parts");
            DropIndex("dbo.PartsPurchaseRecords", new[] { "SuppliersId" });
            DropIndex("dbo.PartsPurchaseRecords", new[] { "PartsId" });
            DropTable("dbo.PartsPurchaseRecords");
        }
    }
}
