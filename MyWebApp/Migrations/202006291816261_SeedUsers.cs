namespace MyWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'951d6093-9a1b-426d-8470-1798842adac8', N'TheAdmin@pp.com', 0, N'AIJ0ar2ayZuPL7rk7gRLAz/UXIynVtOqOXxckHmmIEmX9gf7lOMyQpQ2HOrqGY+vXQ==', N'57b2a9b7-84c3-438e-9286-a54d9e7a1a1c', NULL, 0, 0, NULL, 1, 0, N'TheAdmin@pp.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ce66d89a-5bdc-42d3-a819-770d8f855d7d', N'guest@pp.com', 0, N'AIlKM+QdaFk0vKN+glE9jVKvdEUeJJDXMqRXHm+O0R+FYNRYy5Pu23Fgj85+9jx2qw==', N'40c8f797-c294-4f91-a563-957d01015048', NULL, 0, 0, NULL, 1, 0, N'guest@pp.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a4b1914d-e832-4691-94d4-5e0314b52434', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'951d6093-9a1b-426d-8470-1798842adac8', N'a4b1914d-e832-4691-94d4-5e0314b52434')

");
        }
        
        public override void Down()
        {
        }
    }
}
