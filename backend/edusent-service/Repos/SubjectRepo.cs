using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using edusent_service.Models;
using edusent_service.Models.ViewModels;
using edusent_service.Repos.Base;
using edusent_service.Repos.Interfaces;
using edusent_service.EF;
using System.Linq;
using System;

namespace edusent_service.Repos
{
    public class SubjectRepo : BaseRepo<Subject>, ISubjectRepo
    {

        public SubjectRepo(DbContextOptions options) : base(options) { }

        protected override IQueryable<Subject> Include(DbSet<Subject> set) => set;


        public IEnumerable<Subject> GetAllBySubject(string term)
        {
            
            List<Subject> data = table.Where(x => x.Name.ToLower().Contains( term.ToLower() )).ToList();

            return data;
        }
        public string GetSubjectsById(string userId)
        {
            List<Subject> data = table.Where(x => x.UserId == userId).ToList();

            string result = "";

            foreach(Subject item in data )
            {
                result += item.Name + " ";
            }

            return result;
        }
    }
}