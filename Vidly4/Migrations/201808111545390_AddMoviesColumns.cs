namespace Vidly4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoviesColumns : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "MovieGenere_Id", "dbo.MovieGeneres");
            DropIndex("dbo.Movies", new[] { "MovieGenere_Id" });
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "AddDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "MovieGenere_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "MovieGenere_Id");
            AddForeignKey("dbo.Movies", "MovieGenere_Id", "dbo.MovieGeneres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieGenere_Id", "dbo.MovieGeneres");
            DropIndex("dbo.Movies", new[] { "MovieGenere_Id" });
            AlterColumn("dbo.Movies", "MovieGenere_Id", c => c.Int());
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "AddDate");
            DropColumn("dbo.Movies", "ReleaseDate");
            CreateIndex("dbo.Movies", "MovieGenere_Id");
            AddForeignKey("dbo.Movies", "MovieGenere_Id", "dbo.MovieGeneres", "Id");
        }
    }
}
