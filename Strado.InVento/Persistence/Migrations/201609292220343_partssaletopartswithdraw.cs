namespace Strado.InVento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class partssaletopartswithdraw : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PartsSaleHistories", newName: "PartsWithdrawHistories");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.PartsWithdrawHistories", newName: "PartsSaleHistories");
        }
    }
}
