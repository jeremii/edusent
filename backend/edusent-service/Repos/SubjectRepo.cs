using Microsoft.EntityFrameworkCore;
using edusent_service.Models;
using edusent_service.Repos.Base;
using edusent_service.Repos.Interfaces;
using System.Linq;

namespace edusent_service.Repos
{
    public class SubjectRepo : BaseRepo<Subject>, ISubjectRepo
    {
        public SubjectRepo(DbContextOptions options) : base(options) { }

        protected override IQueryable<Subject> Include(DbSet<Subject> set) => set;
    }
}
