namespace Strado.InVento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PartsWithdrawHistoryModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PartsSaleHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartsId = c.Int(nullable: false),
                        SoldDate = c.DateTime(nullable: false),
                        SoldPrice = c.Double(nullable: false),
                        QtyWithdrawn = c.Int(nullable: false),
                        WithdrawlReason = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parts", t => t.PartsId, cascadeDelete: true)
                .Index(t => t.PartsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PartsSaleHistories", "PartsId", "dbo.Parts");
            DropIndex("dbo.PartsSaleHistories", new[] { "PartsId" });
            DropTable("dbo.PartsSaleHistories");
        }
    }
}
