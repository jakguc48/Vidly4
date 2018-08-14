namespace Vidly4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addtesttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MovieGenereId = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        AddDate = c.DateTime(nullable: false),
                        NumberInStock = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MovieGeneres", t => t.MovieGenereId, cascadeDelete: true)
                .Index(t => t.MovieGenereId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tests", "MovieGenereId", "dbo.MovieGeneres");
            DropIndex("dbo.Tests", new[] { "MovieGenereId" });
            DropTable("dbo.Tests");
        }
    }
}
