using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace edusent_service.EF
{
    public class DbInitializer
    {
        private EdusentContext _context;

        public DbInitializer(EdusentContext context)
        {
            _context = context;
        }

        public static void InitializeData(EdusentContext context)
        {
            context.Database.Migrate();
            ClearData(context);
            SeedData(context);
        }

        public static void ClearData(EdusentContext context)
        {
            context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[AspNetUsers]");
            context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[Sessions]");
            context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[Students]");
            context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[Teachers]");
            context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[Ratings]");
            context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[Subjects]");
        }

        private static void SeedData(EdusentContext context)
        {
            string users = File.ReadAllText(@"./SampleData/dbo.AspNetUsers.data.sql");
            string sessions = File.ReadAllText(@"./SampleData/dbo.Sessions.data.sql");
            string students = File.ReadAllText(@"./SampleData/dbo.Students.data.sql");
            string teachers = File.ReadAllText(@"./SampleData/dbo.Teachers.data.sql");
            string ratings = File.ReadAllText(@"./SampleData/dbo.Ratings.data.sql");
            string subjects = File.ReadAllText(@"./SampleData/dbo.Subjects.data.sql");

            context.Database.ExecuteSqlCommand(users);
            context.Database.ExecuteSqlCommand(sessions);
            context.Database.ExecuteSqlCommand(students);
            context.Database.ExecuteSqlCommand(teachers);
            context.Database.ExecuteSqlCommand(ratings);
            context.Database.ExecuteSqlCommand(subjects);

        }
    }
}
