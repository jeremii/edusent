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
{

    [Route("[controller]")]

    public class SessionsController : Controller
    {
        private ISessionRepo Repo { get; set; }

        
        public SessionsController(ISessionRepo repo)

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

        [HttpGet("GetStatus/{id}")]
        public async Task<IActionResult> GetStatus(string id )
        {
            var data = await Repo.Find( x => x.Id == id);

            return data == null ? (IActionResult)NotFound() : new ObjectResult(data.Status);
        }

        //Task<int> SetStatus(string id, SessionStatus status, bool persist = true);

        //Task<IEnumerable<Session>> GetAllByUserId(string userId);

        [HttpPost]
        public async Task<IActionResult> Create(Session model)
        {
            await Repo.Create(model);

            return Created("Get", new { id = model.Id });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Session model)
        {
            var data = await Repo.Update(model);
            return data == null ? (IActionResult) NotFound() : (IActionResult) Created("Get", new { id = model.Id });
        }
    }
}
