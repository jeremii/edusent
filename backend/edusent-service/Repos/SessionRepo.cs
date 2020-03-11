using Microsoft.EntityFrameworkCore;
using edusent_service.Models;
using edusent_service.Repos.Base;
using edusent_service.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using edusent_service.EF;
using Microsoft.EntityFrameworkCore.Storage;

namespace edusent_service.Repos
{
    public class SessionRepo : BaseRepo<Session>, ISessionRepo
    {
        public readonly EdusentContext Db;
        public DbSet<Session> Table { get; }

        public SessionRepo(DbContextOptions<EdusentContext> options)
        {
            Db = new EdusentContext(options);
            Table = Db.Set<Session>();
        }
        public SessionRepo(DbContextOptions options) : base(options) { }

        protected override IQueryable<Session> Include(DbSet<Session> set) => set.Include(x => x.Student).Include(x => x.Teacher);

        public async Task<SessionStatus> GetStatus(string id)
        {
            Session session = Table.Where(e => e.Id.Equals(id)).First();

            return session.Status;

        }
        public async Task<int> SetStatus(string id, SessionStatus status, bool persist = true)
        {
            Session session = Table.Where(e => e.Id.Equals(id)).First();
            session.Status = status;
            Table.Update(session);
            
            return persist ? SaveChanges() : 0;
        }

        public async Task<IEnumerable<Session>> GetAllByUserId(string userId)
        {
            IEnumerable<Session> results = Table.Where(e => e.TeacherId == userId || e.StudentId == userId);
            List<Session> sessions = new List<Session>();
            foreach (Session sesh in results) sessions.Add(sesh);
            return sessions;
        }
        public int SaveChanges()
        {
            try
            {
                return Db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}