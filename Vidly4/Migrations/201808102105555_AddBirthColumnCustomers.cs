namespace Vidly4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthColumnCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("Customers", "Birthdate", c =>c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
        }
    }
}
