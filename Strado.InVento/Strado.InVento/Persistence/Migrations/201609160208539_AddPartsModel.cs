namespace Strado.InVento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPartsModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartName = c.String(nullable: false, maxLength: 255),
                        PartImageUrl = c.String(maxLength: 255),
                        PartDetails = c.String(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                        Categories_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Categories_Id)
                .Index(t => t.BrandId)
                .Index(t => t.Categories_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parts", "Categories_Id", "dbo.Categories");
            DropForeignKey("dbo.Parts", "BrandId", "dbo.Brands");
            DropIndex("dbo.Parts", new[] { "Categories_Id" });
            DropIndex("dbo.Parts", new[] { "BrandId" });
            DropTable("dbo.Parts");
        }
    }
}
