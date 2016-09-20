namespace Strado.InVento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverRideConventionsforBrand : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Brands", "LogoImgSrc", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Brands", "LogoImgSrc", c => c.Int(nullable: false));
        }
    }
}
