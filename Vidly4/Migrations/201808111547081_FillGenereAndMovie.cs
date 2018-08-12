namespace Vidly4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FillGenereAndMovie : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO [dbo].[MovieGeneres] ([GenereName]) VALUES ('Comedy')");
            Sql("INSERT INTO [dbo].[MovieGeneres] ([GenereName]) VALUES ('Horror')");
            Sql("INSERT INTO [dbo].[MovieGeneres] ([GenereName]) VALUES ('Fabular')");
            Sql("INSERT INTO [dbo].[MovieGeneres] ([GenereName]) VALUES ('Fantasy')");
            Sql("INSERT INTO [dbo].[MovieGeneres] ([GenereName]) VALUES ('Sci-fi')");
            Sql("INSERT INTO [dbo].[MovieGeneres] ([GenereName]) VALUES ('Romantic')");


            Sql("INSERT INTO [dbo].[Movies] (Name, MovieGenere_Id, ReleaseDate, AddDate, NumberInStock) VALUES ('Shrek!', 1, '06/26/2001', GETDATE() , 15)");
            Sql("INSERT INTO [dbo].[Movies] (Name, MovieGenere_Id, ReleaseDate, AddDate, NumberInStock) VALUES ('Dracula', 2, '05/21/1931', GETDATE() , 3)");
            Sql("INSERT INTO [dbo].[Movies] (Name, MovieGenere_Id, ReleaseDate, AddDate, NumberInStock) VALUES ('Frankenstein', 2, '11/10/1930', GETDATE() , 3)");
            Sql("INSERT INTO [dbo].[Movies] (Name, MovieGenere_Id, ReleaseDate, AddDate, NumberInStock) VALUES ('Riders of the lost ark', 3, '06/26/1975', GETDATE() , 20)");
            Sql("INSERT INTO [dbo].[Movies] (Name, MovieGenere_Id, ReleaseDate, AddDate, NumberInStock) VALUES ('Love actually', 6, '12/22/2007', GETDATE() , 103)");
            Sql("INSERT INTO [dbo].[Movies] (Name, MovieGenere_Id, ReleaseDate, AddDate, NumberInStock) VALUES ('Lord of the Rings: Fellowship of the ring', 4, '06/26/2001', GETDATE() , 10)");
            Sql("INSERT INTO [dbo].[Movies] (Name, MovieGenere_Id, ReleaseDate, AddDate, NumberInStock) VALUES ('Lord of the Rings: The two towers', 4, '06/26/2003', GETDATE() , 12)");
            Sql("INSERT INTO [dbo].[Movies] (Name, MovieGenere_Id, ReleaseDate, AddDate, NumberInStock) VALUES ('Lord of the Rings: Return of the king', 4, '06/26/2004', GETDATE() , 7)");
            Sql("INSERT INTO [dbo].[Movies] (Name, MovieGenere_Id, ReleaseDate, AddDate, NumberInStock) VALUES ('Star Trek II: Wrath of Khan', 1, '01/11/1976', GETDATE() , 2)");





        }
        
        public override void Down()
        {
        }
    }
}
