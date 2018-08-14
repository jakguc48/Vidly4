namespace Vidly4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMovieTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "MovieGenere_Id", "dbo.MovieGeneres");
            DropIndex("dbo.Movies", new[] { "MovieGenere_Id" });
            AlterColumn("dbo.Movies", "MovieGenere_Id", c => c.Int());
            CreateIndex("dbo.Movies", "MovieGenere_Id");
            AddForeignKey("dbo.Movies", "MovieGenere_Id", "dbo.MovieGeneres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieGenere_Id", "dbo.MovieGeneres");
            DropIndex("dbo.Movies", new[] { "MovieGenere_Id" });
            AlterColumn("dbo.Movies", "MovieGenere_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "MovieGenere_Id");
            AddForeignKey("dbo.Movies", "MovieGenere_Id", "dbo.MovieGeneres", "Id", cascadeDelete: true);
        }
    }
}
