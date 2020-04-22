INSERT INTO [dbo].[AspNetUsers]
    ([Id], [UserName], [NormalizedUsername], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName], [EmailConfirmed])
VALUES
    (N'1234', N'TestUser', N'TESTUSER', N'test@gmail.com', N'TEST@GMAIL.COM' , N'AQAAAAEAACcQAAAAEIUEM4IbTgIex/XyTSMtqEFDIxiFU8uVjsfMIXcdsX6RAPd7xfQeo8VUTIgD90BLlA==', N'YMWST2SD23HET7HVSN266YTFJ44GOCIZ', N'c6445081-f8f5-441e-ae73-edfe7aa2776b', 0,0,1, 0, N'User', N'Test' , N'User', 1)
INSERT INTO [dbo].[AspNetUsers]
    ([Id], [UserName], [NormalizedUsername], [Email], [NormalizedEmail], [PasswordHash],[SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName], [EmailConfirmed])
VALUES
    (N'9112', N'teacherTestUser', N'TEACHERTESTUSER', N'teachertestuser@gmail.com', N'TEACHERTESTUSER@GMAIL.CO,' , N'AQAAAAEAACcQAAAAEIUEM4IbTgIex/XyTSMtqEFDIxiFU8uVjsfMIXcdsX6RAPd7xfQeo8VUTIgD90BLlA==', N'YRLKIM5YEKRFIGPWMQ4DYMXLQ77X3FES', N'f2943b6f-65c6-42f0-a8de-2d35b9282f42', 0,0,1, 0, N'Teacher', N'T' , N'Teacher', 1)
INSERT INTO [dbo].[AspNetUsers]
    ([Id], [UserName], [NormalizedUsername], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName], [EmailConfirmed])
VALUES
    (N'2112', N'studentTestUser', N'STUDENTTESTUSER', N'studenttestuser@gmail.com', N'STUDENTTESTUSER@GMAIL.COM', N'AQAAAAEAACcQAAAAEIUEM4IbTgIex/XyTSMtqEFDIxiFU8uVjsfMIXcdsX6RAPd7xfQeo8VUTIgD90BLlA==', N'YRLKIM5YEKRFIGPWMQ4DYMXLQ77X3FES', N'f2943b6f-65c6-42f0-a8de-2d35b9282f42', 0,0,1, 0, N'Student', N'S' , N'Student', 1)