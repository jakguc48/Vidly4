namespace Vidly4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropNameMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
        
        public override void Down()
        {
        }
    }
}
