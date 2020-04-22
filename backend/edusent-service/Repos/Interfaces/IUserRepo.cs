﻿using System;
using edusent_service.Repos.Base;
using edusent_service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace edusent_service.Repos.Interfaces
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> Get(string id);
        Task<IEnumerable<User>> FindUsers(string keyword);
        Task<int> Update(User user, bool persists = true);
        Task<string> FindIdByName(string first, string last);
        Task<string> FindIdByEmail(string email);
        Task<string> FindIdByUsername(string username);
        Task<string> GetUsernameByEmail(string email);
        Task<bool> UsernameExists(string username);
        Task<bool> EmailExists(string email);
    }
}
