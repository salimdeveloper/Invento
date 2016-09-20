namespace Strado.InVento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateCategories : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories(CategoryName,IsDelete) VALUES ('Domestic RO',0)");
            Sql("INSERT INTO Categories(CategoryName,IsDelete) VALUES ('Industrial RO',0)");
            Sql("INSERT INTO Categories(CategoryName,IsDelete) VALUES ('Commercial RO',0)");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Categories WHERE Id IN (1,2,3)");
        }
    }
}
