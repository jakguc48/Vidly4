namespace Vidly4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterColumnBirthdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "BirthDate", c=> c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
        }
    }
}
