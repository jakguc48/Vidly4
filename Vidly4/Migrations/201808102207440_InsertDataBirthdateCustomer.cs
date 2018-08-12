namespace Vidly4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertDataBirthdateCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate = '06/26/1982' WHERE id=1");
            Sql("UPDATE Customers SET BirthDate = '11/12/1985' WHERE id=2");
            Sql("UPDATE Customers SET BirthDate = '01/30/1999' WHERE id=3");
        }
        
        public override void Down()
        {
        }
    }
}
