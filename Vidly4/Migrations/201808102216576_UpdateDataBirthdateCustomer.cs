namespace Vidly4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataBirthdateCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = NULL WHERE id<3");
        }
        
        public override void Down()
        {
        }
    }
}
