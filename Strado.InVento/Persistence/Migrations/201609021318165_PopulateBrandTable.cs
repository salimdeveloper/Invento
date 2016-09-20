namespace Strado.InVento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBrandTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Brands(BrandName,LogoImgSrc) Values('Grand Forest','~/Images/BrandImages/gforestlogo.png')");
            Sql("INSERT INTO Brands(BrandName,LogoImgSrc) Values('Kem Flow','~/Images/BrandImages/kemflowlogo.png')");
            Sql("INSERT INTO Brands(BrandName,LogoImgSrc) Values('Decent','~/Images/BrandImages/decentlogo.png')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Brands WHERE Id IN (1,2,3)");
        }
    }
}
