using System;
using edusent_service.Repos.Base;
using edusent_service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace edusent_service.Repos.Interfaces
{
    public interface ISessionRepo : IRepo<Session>
    {

        Task<IEnumerable<Session>> GetAllByUserId(string userId);

    };
}
