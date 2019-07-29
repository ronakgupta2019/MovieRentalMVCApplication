namespace MovieRentalMVCApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataInUsersTables : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1e403d26-887b-43fb-aab8-b00f1f2dd494', N'domain@admin.com', 0, N'AML1nytr5DeIEw9ZU8NInAp8vXh4/71LgpSfOEcihsYD2k/mKfMUSrrXCerSfdvaJg==', N'af1ad16a-a497-4b18-927d-bcebba5fc2cd', NULL, 0, 0, NULL, 1, 0, N'domain@admin.com')
          INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2bf14367-da1b-4c43-8c45-b03459e846d1', N'rg@xyz.com', 0, N'AA6aasrxdCLzNsqBQeVdt9BoLXeb+BgnvgHpFqrZO38wRBu3lBzU7034uhVC1oOEog==', N'51f267f9-4673-45c0-bec7-b90109428a63', NULL, 0, 0, NULL, 1, 0, N'rg@xyz.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'98a47d3f-e04a-4189-b754-0f96a1c3c655', N'domain1@admin.com', 0, N'AJun1YGDRPSTAm9Ote7Fd9+dVohpto1qDs+tzxO2lDbDmDPWlMScdRb2XK+ACCq5Aw==', N'a82c4701-bd61-4ff2-82f8-5f01a7d03c28', NULL, 0, 0, NULL, 1, 0, N'domain1@admin.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'73e8b7e6-7e07-46ea-a245-2a064d626c2f', N'Admin')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1c0bf0e1-db30-44ba-8ff3-a6171c1a64c6', N'CanCreateCustomer')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'98a47d3f-e04a-4189-b754-0f96a1c3c655', N'73e8b7e6-7e07-46ea-a245-2a064d626c2f')


");
        }
        
        public override void Down()
        {
        }
    }
}
