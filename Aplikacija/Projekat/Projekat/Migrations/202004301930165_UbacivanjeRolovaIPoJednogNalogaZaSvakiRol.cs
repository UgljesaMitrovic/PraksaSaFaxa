namespace Projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UbacivanjeRolovaIPoJednogNalogaZaSvakiRol : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5cf0949e-20d7-41bc-9299-e60da048218b', N'guest1@praksa.com', 0, N'ABS82yVoS4AatVXBpxcBelwC7Llm2gfkuOZAmOlBQKbUZHIagILUGjxddnuoivLtgg==', N'713fb6e0-c841-459d-982d-d3c4e8ec43d7', NULL, 0, 0, NULL, 1, 0, N'guest1@praksa.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'69466d06-33bf-402c-811a-4bf050df2e8c', N'firma1@praksa.com', 0, N'AOMrMGRD134wExJICtQ8GidX3t9JwjBm5gYEebFH+nR9vr692XVvrhd5X0Fj97b3rg==', N'61f55f68-da83-40f9-9ea0-c441e80449ac', NULL, 0, 0, NULL, 1, 0, N'firma1@praksa.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dc5786b1-4d0c-4061-a872-0f5f9aef2f22', N'admin@praksa.com', 0, N'AI2okpqzSaNEiGAVLAXvCeS2JamcKxOaJ8j4rrUKhtKFKyX91cYDJWgkWuBBUCAXQw==', N'4b0c2e5d-3f65-40d2-885e-420d48c771c0', NULL, 0, 0, NULL, 1, 0, N'admin@praksa.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e4a24f08-9ac5-4907-9b32-a6e3b40ebaf4', N'student1@praksa.com', 0, N'ADzDfoqvDWzk3Ddq/B9M2xIwOSu70y2SqrkOh17vX0ZlA06EGgmDIub3e/4LIgqZlQ==', N'cd7547df-a0a8-46f5-a77f-cb2b2419defa', NULL, 0, 0, NULL, 1, 0, N'student1@praksa.com')

                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'40140c51-ae30-4d09-b7ce-8fd05fd97501', N'Admin')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ed97dc7c-6fbd-40e2-ade1-63c397cf4fee', N'Firma')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a44d4e2a-f4c8-492c-9557-28d4d6fc6944', N'Student')

                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dc5786b1-4d0c-4061-a872-0f5f9aef2f22', N'40140c51-ae30-4d09-b7ce-8fd05fd97501')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e4a24f08-9ac5-4907-9b32-a6e3b40ebaf4', N'a44d4e2a-f4c8-492c-9557-28d4d6fc6944')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'69466d06-33bf-402c-811a-4bf050df2e8c', N'ed97dc7c-6fbd-40e2-ade1-63c397cf4fee')
               ");
        }
        
        public override void Down()
        {
        }
    }
}
