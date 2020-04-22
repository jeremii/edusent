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
using Newtonsoft.Json;


namespace edusent_service.Controllers

    [Route("[controller]")]
    public class RatingsController : Controller
    {
        private IRatingRepo Repo { get; set; }

        
        public RatingsController(IRatingRepo repo)
        {
            Repo = repo;   
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = Repo.GetAll();

            return data == null ? (IActionResult)NotFound() : new ObjectResult(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get( string id )
        {
            var data = await Repo.Find(x => x.Id == id);

            return data == null ? (IActionResult)NotFound() : new ObjectResult(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create( Rating model)
        {
            await Repo.Create(model);

            return Created("Get", new { id = model.Id });
        }
        
        
        //Task<IEnumerable<Session>> GetAllByUserId(string userId);

        
    }
}
