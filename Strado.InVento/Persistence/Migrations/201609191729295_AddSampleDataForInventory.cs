namespace Strado.InVento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSampleDataForInventory : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [Inventories](PartsId,QtyInStock,LastUpdated) values(1,40,'08-12-2016')");
            Sql("INSERT INTO [Inventories](PartsId,QtyInStock,LastUpdated) values(2,20,'08-12-2016')");
            Sql("INSERT INTO [Inventories](PartsId,QtyInStock,LastUpdated) values(3,50,'08-12-2016')");
            Sql("INSERT INTO [Inventories](PartsId,QtyInStock,LastUpdated) values(4,34,'08-12-2016')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM [Inventories] WHERE Id IN (1,2,3,4) ");
        }
    }
}
