using Microsoft.EntityFrameworkCore;
using edusent_service.Models;
using edusent_service.Repos.Base;
using edusent_service.Repos.Interfaces;
using System.Linq;

namespace edusent_service.Repos
{
    public class StudentRepo : BaseRepo<Student>, IStudentRepo
    {
        public StudentRepo(DbContextOptions options) : base(options) { }

        protected override IQueryable<Student> Include(DbSet<Student> set) => set.Include(x => x.Sessions);
    }
}
