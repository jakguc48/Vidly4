namespace Vidly4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyMovieModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "MovieGenere_Id", "dbo.MovieGeneres");
            DropIndex("dbo.Movies", new[] { "MovieGenere_Id" });
            RenameColumn(table: "dbo.Movies", name: "MovieGenere_Id", newName: "MovieGenereId");
            AlterColumn("dbo.Movies", "MovieGenereId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "MovieGenereId");
            AddForeignKey("dbo.Movies", "MovieGenereId", "dbo.MovieGeneres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieGenereId", "dbo.MovieGeneres");
            DropIndex("dbo.Movies", new[] { "MovieGenereId" });
            AlterColumn("dbo.Movies", "MovieGenereId", c => c.Int());
            RenameColumn(table: "dbo.Movies", name: "MovieGenereId", newName: "MovieGenere_Id");
            CreateIndex("dbo.Movies", "MovieGenere_Id");
            AddForeignKey("dbo.Movies", "MovieGenere_Id", "dbo.MovieGeneres", "Id");
        }
    }
}
