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
    public class SubjectsController : Controller
    {
        private ISubjectRepo Repo { get; set; }

        
        public SubjectsController(ISubjectRepo repo)

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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Subject model)
        {
            var data = await Repo.Update(model);
            return data == null ? (IActionResult) NotFound() : (IActionResult) Created("Get", new { id = model.Id });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (string id )
        {
            Subject data = await Repo.Remove(x => x.Id == id);

            return data == null ? (IActionResult)NotFound() : Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Subject model)
        {
            await Repo.Create(model);

            return Created("Get", new { id = model.Id });
        }
    }
}
