using Microsoft.EntityFrameworkCore;
using edusent_service.Models;
using edusent_service.Repos.Base;
using edusent_service.Repos.Interfaces;
using System.Linq;

namespace edusent_service.Repos
{
    public class TeacherRepo : BaseRepo<Teacher>, ITeacherRepo
    {
        public TeacherRepo(DbContextOptions options) : base(options) { }

        protected override IQueryable<Teacher> Include(DbSet<Teacher> set) => set.Include(x => x.Sessions);
    }
}
