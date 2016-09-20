namespace Strado.InVento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FluentAnnotationsforBrand : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Brands", "BrandName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Brands", "LogoImgSrc", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Brands", "LogoImgSrc", c => c.String());
            AlterColumn("dbo.Brands", "BrandName", c => c.String());
        }
    }
}
