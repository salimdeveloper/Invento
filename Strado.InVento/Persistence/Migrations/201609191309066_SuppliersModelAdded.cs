namespace Strado.InVento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SuppliersModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(nullable: false, maxLength: 255),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Suppliers", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Suppliers", new[] { "AddressId" });
            DropTable("dbo.Suppliers");
        }
    }
}
