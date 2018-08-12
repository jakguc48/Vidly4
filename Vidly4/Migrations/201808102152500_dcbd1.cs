namespace Vidly4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dcbd1 : DbMigration
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
