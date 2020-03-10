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
        }

        private static void SeedData(EdusentContext context)
        {
            string users = File.ReadAllText(@"./SampleData/dbo.AspNetUsers.data.sql");

            context.Database.ExecuteSqlCommand(users);
            
        }
    }
}
