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

    [Route("[controller]")]
    public class UsersController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _iMapper;
        private IUserRepo Repo { get; set; }
        public IConfiguration Configuration { get; }

        public UsersController(IUserRepo repo,
            UserManager<User> userManager,
            SignInManager<User> signInManager, IConfiguration configuration, IMapper iMapper)

        {
            Repo = repo;
            _userManager = userManager;
            _signInManager = signInManager;
            Configuration = configuration;
            _iMapper = iMapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var data = await Repo.GetAll();
            return data == null ? (IActionResult)NotFound() : new ObjectResult(data);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var data = await Repo.Get(id);
            return data == null ? (IActionResult)NotFound() : new ObjectResult(data);
        }
        [HttpGet("find/{name}")]
        public async Task<IActionResult> FindUser(string name)
        {
            var data = await Repo.FindUsers(name);
            return data == null ? (IActionResult)NotFound() : new ObjectResult(data);
        }

        [HttpGet("info")]
        public async Task<IActionResult> GetUserInfo()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return BadRequest(new ErrorMessage("No cookie found for user."));
            }

            var userInfo = _iMapper.Map<UserInfoViewModel>(user);
            return Ok(userInfo);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel newUser)
        {

            User user = new User();

            if (newUser.Password == null)
            {
                return BadRequest(new ErrorMessage("Password cannot be empty."));
            }

            if (newUser.Email != null)
                user.Email = newUser.Email;
            else
                return BadRequest();

            if (!Regex.Match(newUser.Email, ".+@.+[.]\\w").Success)
            {
                return BadRequest(new ErrorMessage("Invalid email address."));

            }
            // Validate: email doesn't already exist.
            if (await Repo.EmailExists(newUser.Email))
            {
                return BadRequest(new ErrorMessage("Email already exists!"));
            }

            // Now, create user.
            var result = await _userManager.CreateAsync(user, newUser.Password);

            if (result.Succeeded)
            {
                
                var corsConfig = Configuration.GetSection("Cors").Get<CorsConfig>();
                string frontendUrl = corsConfig.FrontendDomain;

                return Created($"users/{user.Id}", new { Id = user.Id });
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return NotFound();
        }

        

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                // Gets username because login uses username.
                // TODO: Implement custom login method that uses email instead.
                string username = null;
                try
                {
                    username = await Repo.GetUsernameByEmail(model.Email);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);

                    return BadRequest(new ErrorMessage("User does not exist."));
                }

                // This does not count login failures towards account lockout
                // To enable password failures to trigger account lockout,
                // set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(username, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {

                    return Ok();
                }
                return BadRequest(new ErrorMessage("Check email and/or password."));
            }

            // If execution got this far, something failed, redisplay the form.
            return NotFound();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            if (_signInManager.IsSignedIn(User))
            {
                await _signInManager.SignOutAsync();
                return Ok("Logout complete!");
            }
            return BadRequest();
        }
    }
}
