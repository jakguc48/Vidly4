namespace Vidly4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropColBirt : DbMigration
    {
        public override void Up()
        {
            DropColumn("Customers", "Birthdate");
        }
        
        public override void Down()
        {
        }
    }
}
