namespace Strado.InVento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SupplierIsDeactive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "IsDeactive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Suppliers", "IsDeactive");
        }
    }
}
