using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using edusent_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edusent_service.EF
{
    public class EdusentContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<User> User { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Rating> Ratings { get; set; }


        public EdusentContext()
        {

        }

        public EdusentContext(DbContextOptions options) : base(options)
        {
            try
            {
                Database.Migrate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
