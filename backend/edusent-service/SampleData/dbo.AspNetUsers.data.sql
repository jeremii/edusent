INSERT INTO [dbo].[AspNetUsers]
    ([Id], [UserName], [NormalizedUsername], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName], [EmailConfirmed], [MoneyMade], [isTeacher], [Phone], [Rating])
VALUES
    (N'1234', N'TestUser', N'TESTUSER', N'test@gmail.com', N'TEST@GMAIL.COM' , N'AQAAAAEAACcQAAAAEIUEM4IbTgIex/XyTSMtqEFDIxiFU8uVjsfMIXcdsX6RAPd7xfQeo8VUTIgD90BLlA==', N'YMWST2SD23HET7HVSN266YTFJ44GOCIZ', N'c6445081-f8f5-441e-ae73-edfe7aa2776b', 0,0,1, 0, N'User', N'Test' , N'User', 1, '0.0', 0, '3045555555', '5.0');



INSERT INTO [dbo].[AspNetUsers]
    ([Id], [UserName], [NormalizedUsername], [Email], [NormalizedEmail], [PasswordHash],[SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName], [EmailConfirmed], [MoneyMade], [isTeacher], [Phone], [Rating])
VALUES
    (N'1111', N'Teacher_1', N'TEACHER_1', N'teacher1@gmail.com', N'TEACHER1@GMAIL.COM' , N'AQAAAAEAACcQAAAAEIUEM4IbTgIex/XyTSMtqEFDIxiFU8uVjsfMIXcdsX6RAPd7xfQeo8VUTIgD90BLlA==', N'YRLKIM5YEKRFIGPWMQ4DYMXLQ77X3FES', N'f2943b6f-65c6-42f0-a8de-2d35b9282f42', 0, 0, 1, 0, N'User', N'Joe' , N'Schmoe', 1, '400.0', 1, '3045555555', '5.0');

INSERT INTO [dbo].[AspNetUsers]
    ([Id], [UserName], [NormalizedUsername], [Email], [NormalizedEmail], [PasswordHash],[SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName], [EmailConfirmed], [MoneyMade], [isTeacher], [Phone], [Rating])
VALUES
    (N'1112', N'Teacher_2', N'TEACHER_2', N'teacher2@gmail.com', N'TEACHER2@GMAIL.COM' , N'AQAAAAEAACcQAAAAEIUEM4IbTgIex/XyTSMtqEFDIxiFU8uVjsfMIXcdsX6RAPd7xfQeo8VUTIgD90BLlA==', N'YRLKIM5YEKRFIGPWMQ4DYMXLQ77X3FES', N'f2943b6f-65c6-42f0-a8de-2d35b9282f42', 0, 0, 1, 0, N'User', N'John' , N'Two', 1, '1000.0', 1, '3045555555', '5.0');


INSERT INTO [dbo].[AspNetUsers]
    ([Id], [UserName], [NormalizedUsername], [Email], [NormalizedEmail], [PasswordHash],[SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName], [EmailConfirmed], [MoneyMade], [isTeacher], [Phone], [Rating])
VALUES
    (N'1113', N'Teacher_3', N'TEACHER_3', N'teacher3@gmail.com', N'TEACHER3@GMAIL.COM' , N'AQAAAAEAACcQAAAAEIUEM4IbTgIex/XyTSMtqEFDIxiFU8uVjsfMIXcdsX6RAPd7xfQeo8VUTIgD90BLlA==', N'YRLKIM5YEKRFIGPWMQ4DYMXLQ77X3FES', N'f2943b6f-65c6-42f0-a8de-2d35b9282f42', 0, 0, 1, 0, N'User', N'Sally' , N'Three', 1, '50.0', 1, '3045555555', '5.0');
INSERT INTO [dbo].[AspNetUsers]
    ([Id], [UserName], [NormalizedUsername], [Email], [NormalizedEmail], [PasswordHash],[SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName], [EmailConfirmed], [MoneyMade], [isTeacher], [Phone], [Rating])
VALUES
    (N'1114', N'Teacher_4', N'TEACHER_4', N'teacher4@gmail.com', N'TEACHER4@GMAIL.COM' , N'AQAAAAEAACcQAAAAEIUEM4IbTgIex/XyTSMtqEFDIxiFU8uVjsfMIXcdsX6RAPd7xfQeo8VUTIgD90BLlA==', N'YRLKIM5YEKRFIGPWMQ4DYMXLQ77X3FES', N'f2943b6f-65c6-42f0-a8de-2d35b9282f42', 0,0,1, 0, N'User', N'Kim' , N'Four', 1, '200.0', 1, '3045555555', '5.0');


INSERT INTO [dbo].[AspNetUsers]
    ([Id], [UserName], [NormalizedUsername], [Email], [NormalizedEmail], [PasswordHash],[SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName], [EmailConfirmed], [MoneyMade], [isTeacher], [Phone], [Rating])
VALUES
    (N'2221', N'Student_1', N'STUDENT_1', N'student1@gmail.com', N'STUDENT1@GMAIL.COM' , N'AQAAAAEAACcQAAAAEIUEM4IbTgIex/XyTSMtqEFDIxiFU8uVjsfMIXcdsX6RAPd7xfQeo8VUTIgD90BLlA==', N'YRLKIM5YEKRFIGPWMQ4DYMXLQ77X3FES', N'f2943b6f-65c6-42f0-a8de-2d35b9282f42', 0, 0, 1, 0, N'User', N'Student' , N'One', 1, '0', 1, '3045555555', '5.0');



INSERT INTO [dbo].[AspNetUsers]
    ([Id], [UserName], [NormalizedUsername], [Email], [NormalizedEmail], [PasswordHash],[SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName], [EmailConfirmed], [MoneyMade], [isTeacher], [Phone], [Rating])
VALUES
    (N'2222', N'Student_2', N'STUDENT_2', N'student2@gmail.com', N'STUDENT2@GMAIL.COM' , N'AQAAAAEAACcQAAAAEIUEM4IbTgIex/XyTSMtqEFDIxiFU8uVjsfMIXcdsX6RAPd7xfQeo8VUTIgD90BLlA==', N'YRLKIM5YEKRFIGPWMQ4DYMXLQ77X3FES', N'f2943b6f-65c6-42f0-a8de-2d35b9282f42', 0, 0, 1, 0, N'User', N'Student' , N'Two', 1, '0', 1, '3045555555', '5.0');


INSERT INTO [dbo].[AspNetUsers]
    ([Id], [UserName], [NormalizedUsername], [Email], [NormalizedEmail], [PasswordHash],[SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName], [EmailConfirmed], [MoneyMade], [isTeacher], [Phone], [Rating])
VALUES
    (N'2223', N'Student_3', N'STUDENT_3', N'student3@gmail.com', N'STUDENT3@GMAIL.COM' , N'AQAAAAEAACcQAAAAEIUEM4IbTgIex/XyTSMtqEFDIxiFU8uVjsfMIXcdsX6RAPd7xfQeo8VUTIgD90BLlA==', N'YRLKIM5YEKRFIGPWMQ4DYMXLQ77X3FES', N'f2943b6f-65c6-42f0-a8de-2d35b9282f42', 0, 0, 1, 0, N'User', N'Student' , N'Three', 1, '0', 1, '3045555555', '5.0');


INSERT INTO [dbo].[AspNetUsers]
    ([Id], [UserName], [NormalizedUsername], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName], [EmailConfirmed], [MoneyMade], [isTeacher], [Phone], [Rating])
VALUES
    (N'2224', N'Student_4', N'STUDENT_4', N'student4@gmail.com', N'STUDENT4@GMAIL.COM', N'AQAAAAEAACcQAAAAEIUEM4IbTgIex/XyTSMtqEFDIxiFU8uVjsfMIXcdsX6RAPd7xfQeo8VUTIgD90BLlA==', N'YRLKIM5YEKRFIGPWMQ4DYMXLQ77X3FES', N'f2943b6f-65c6-42f0-a8de-2d35b9282f42', 0,0,1, 0, N'User', N'Student' , N'Four', 1, '0.0', 0, '3045555555', '5.0');
