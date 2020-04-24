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
            
            context.Database.ExecuteSqlCommand("DELETE FROM [edusent].[Sessions]");
            //context.Database.ExecuteSqlCommand("DELETE FROM [edusent].[Students]");
            //context.Database.ExecuteSqlCommand("DELETE FROM [edusent].[Teachers]");
            context.Database.ExecuteSqlCommand("DELETE FROM [edusent].[Ratings]");
            context.Database.ExecuteSqlCommand("DELETE FROM [edusent].[Subjects]");
            context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[AspNetUsers]");
        }

        private static void SeedData(EdusentContext context)
        {
            string users = File.ReadAllText(@"./SampleData/dbo.AspNetUsers.data.sql");

            //string students = File.ReadAllText(@"./SampleData/dbo.Students.data.sql");
            //string teachers = File.ReadAllText(@"./SampleData/dbo.Teachers.data.sql");
            string sessions = File.ReadAllText(@"./SampleData/edusent.Sessions.data.sql");
            string ratings = File.ReadAllText(@"./SampleData/edusent.Ratings.data.sql");
            string subjects = File.ReadAllText(@"./SampleData/edusent.Subjects.data.sql");

            context.Database.ExecuteSqlCommand(users);
            //context.Database.ExecuteSqlCommand(students);
            //context.Database.ExecuteSqlCommand(teachers);
            context.Database.ExecuteSqlCommand(sessions);
            context.Database.ExecuteSqlCommand(ratings);
            //context.Database.ExecuteSqlCommand(subjects);

        }
    }
}
