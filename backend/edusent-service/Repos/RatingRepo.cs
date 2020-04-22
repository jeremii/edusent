using Microsoft.EntityFrameworkCore;
using edusent_service.Models;
using edusent_service.Repos.Base;
using edusent_service.Repos.Interfaces;
using System.Linq;

namespace edusent_service.Repos
{
    public class RatingRepo : BaseRepo<Rating>, IRatingRepo
    {
        public RatingRepo(DbContextOptions options) : base(options) { }

        protected override IQueryable<Rating> Include(DbSet<Rating> set) => set;
    }
}
