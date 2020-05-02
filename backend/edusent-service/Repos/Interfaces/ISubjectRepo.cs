using System;
using edusent_service.Repos.Base;
using edusent_service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using edusent_service.Models.ViewModels;

namespace edusent_service.Repos.Interfaces
{
    public interface ISubjectRepo : IRepo<Subject>
    {
        IEnumerable<Subject> GetAllBySubject(string term);
        string GetSubjectsById(string userId);
    }
}
