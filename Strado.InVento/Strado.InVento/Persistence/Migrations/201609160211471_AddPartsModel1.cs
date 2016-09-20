namespace Strado.InVento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPartsModel1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Parts", "Categories_Id", "dbo.Categories");
            DropIndex("dbo.Parts", new[] { "Categories_Id" });
            RenameColumn(table: "dbo.Parts", name: "Categories_Id", newName: "CategoriesId");
            AlterColumn("dbo.Parts", "CategoriesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Parts", "CategoriesId");
            AddForeignKey("dbo.Parts", "CategoriesId", "dbo.Categories", "Id", cascadeDelete: true);
            DropColumn("dbo.Parts", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parts", "CategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Parts", "CategoriesId", "dbo.Categories");
            DropIndex("dbo.Parts", new[] { "CategoriesId" });
            AlterColumn("dbo.Parts", "CategoriesId", c => c.Int());
            RenameColumn(table: "dbo.Parts", name: "CategoriesId", newName: "Categories_Id");
            CreateIndex("dbo.Parts", "Categories_Id");
            AddForeignKey("dbo.Parts", "Categories_Id", "dbo.Categories", "Id");
        }
    }
}
