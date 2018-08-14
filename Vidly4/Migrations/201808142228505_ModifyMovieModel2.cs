namespace Vidly4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyMovieModel2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "AddDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "AddDate", c => c.DateTime(nullable: false));
        }
    }
}
