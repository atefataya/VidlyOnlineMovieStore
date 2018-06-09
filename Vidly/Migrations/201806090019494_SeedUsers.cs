namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'37fda57c-567a-49d4-b67c-ae3d78ec7bcb', N'admin@vidly.com', 0, N'AGX2WEi3quTYipw2XKKzdDOfboGqUCsu15fNA9xR0M7uUCuvK2qnJBj5f1mdf3ku6w==', N'e0e8f25e-a2f3-4d32-a0a4-9482a1ca09cd', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e6632c0b-394b-4ed2-95b2-c99bca6e2104', N'guest@vidly.com', 0, N'AMKpgnuhFXBy3LPmPeueKVJ2GMc6TC1nxsb7rUxGNgXrR76bqnsQFvTCetmuByshKA==', N'b950eb78-d8eb-47df-8765-fa74e991cdd7', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c8c3e3c2-72c8-483e-98e7-81b6caa32144', N'CanManageMovies')


INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'37fda57c-567a-49d4-b67c-ae3d78ec7bcb', N'c8c3e3c2-72c8-483e-98e7-81b6caa32144')



");
        }
        
        public override void Down()
        {
        }
    }
}
