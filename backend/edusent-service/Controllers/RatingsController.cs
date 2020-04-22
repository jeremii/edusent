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
        [HttpPost("teacher/{sessionId}/{rate}/{reason}")]
        public async Task<IActionResult> RateTeacher(string sessionId, string rate, string reason)
        {
            Rating rating = new Rating
            {
                RateForTeacher = true,
                SessionId = sessionId,
                Stars = Byte.Parse(rate),
                Reason = (Reason)int.Parse(reason)
            };
            var data = await Repo.Create(rating);
            return data == null ? (IActionResult)BadRequest() : new ObjectResult(data);
        }
        [HttpPost("student/{sessionId}/{rate}/{reason}")]
        public async Task<IActionResult> RateStudent(string sessionId, string rate, string reason)
        {
            Rating rating = new Rating
            {
                RateForTeacher = false,
                SessionId = sessionId,
                Stars = Byte.Parse(rate),
                Reason = (Reason)int.Parse(reason)
            };
            var data = await Repo.Create(rating);
            return data == null ? (IActionResult)BadRequest() : new ObjectResult(data);
        }

        
        
    }
}
