namespace Vidly4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomBirt : DbMigration
    {
        public override void Up()
        {
            AddColumn("Customers", "Birthdate", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
        }
    }
}
