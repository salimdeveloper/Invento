namespace Strado.InVento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateBrandsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                        LogoImgSrc = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Brands");
        }
    }
}
