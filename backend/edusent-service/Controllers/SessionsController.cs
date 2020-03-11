using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using edusent_service.Helpers;
using edusent_service.Models;
using edusent_service.Models.ViewModels;
using edusent_service.Repos.Interfaces;

namespace edusent_service.Controllers
{
    public class SessionsController
    {
        public IActionResult GetAll()
        {

        }
        public SessionsController(ISessionRepo repo)

        {
            Repo = repo;
            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<User> data = Repo.GetAll();
            return data == null ? (IActionResult)NotFound() : new ObjectResult(data);
        }

        public IActionResult Create(Session model)
        {

        }
    }
}
