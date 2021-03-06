namespace Vidly4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0c6d9943-80e2-4acf-92da-f3ab41199a8b', N'guest@vidly.com', 0, N'AGZNgVeEWzudPodtHZtZkHuXx6BmMApLtteaLvTb5gvccE0BTLE8yj3k4Ad9XCt5hw==', N'cb8636ef-05e3-4a49-b6e0-fde72d75bc13', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'51938d1e-4dd2-47f0-b232-05f2e10486b0', N'Admin2@vidly.com', 0, N'AIbKRvfiZrOCC5+tpOrEFKvxi0KCHb55HN2QoPlQK89eVy4CQx29bPXpBlEmwYkODw==', N'0a36fd08-79bd-4df1-a0ee-4a3580e42942', NULL, 0, 0, NULL, 1, 0, N'Admin2@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'63c8ca53-d7af-4e59-bc2b-7417b4f5e238', N'admin@vidly.com', 0, N'ANDHt9g44dkw1mT/xtvMX/w7gmADaj4EEHv/6D6gyL4X0+sqwjo1WzM7pFe065maiw==', N'e68915d6-f965-46b8-8aea-8293b918e577', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b9d42a54-956e-4b83-8743-5b2b173ef31e', N'jaja@gmail.com', 0, N'AIJyYiCmoRFcZsDRo8DXD/BeWSA5cdDohNDfu+Zq5/O5DWXuTsbtp78tz5lawqbeSw==', N'663852da-9f2b-4420-8f95-2cd101558fa0', NULL, 0, 0, NULL, 1, 0, N'jaja@gmail.com')

            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'fa152c0d-cf37-4746-a2c4-89e818f9f35c', N'CanManageMovies')


            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'51938d1e-4dd2-47f0-b232-05f2e10486b0', N'fa152c0d-cf37-4746-a2c4-89e818f9f35c')


");
        }
        
        public override void Down()
        {
        }
    }
}
