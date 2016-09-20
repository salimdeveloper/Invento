namespace Strado.InVento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressModelCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address1 = c.String(nullable: false, maxLength: 255),
                        Address2 = c.String(),
                        City = c.String(nullable: false, maxLength: 125),
                        State = c.String(nullable: false, maxLength: 125),
                        Pin = c.String(nullable: false, maxLength: 7),
                        ContactNo = c.String(nullable: false, maxLength: 12),
                        ContactName = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Addresses");
        }
    }
}
