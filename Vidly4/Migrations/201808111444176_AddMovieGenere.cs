namespace Vidly4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieGenere : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieGeneres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenereName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MovieGeneres");
        }
    }
}