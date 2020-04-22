using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using AutoMapper;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using edusent_service.EF;
using edusent_service.Helpers;
using edusent_service.Models;
using edusent_service.Repos;
using edusent_service.Repos.Interfaces;
//using edusent_service.Services;

namespace edusent_service
{
    public class Startup
    {
        readonly string AllowAnywhere = "_AllowAnywhere";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            // Use SQL Database if in Azure, otherwise, use SQLite
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {

                services.AddDbContext<EdusentContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("azure_connection_string")));   
            }
            else
            {
                var corsConfig = Configuration.GetSection("Cors").Get<CorsConfig>();

                services.AddCors(options =>
                {
                    options.AddPolicy(AllowAnywhere,
                        builder =>
                        {
                            builder.WithOrigins(corsConfig.AllDomains)
                                .AllowAnyHeader()
                                .WithExposedHeaders("*")
                                .AllowCredentials()
                                .AllowAnyMethod();
                        });
                });

                services.AddHttpClient("findCalendar", c =>
                {
                    c.BaseAddress = new Uri(Configuration["Google:Uri"]);
                });


                var databaseConfig = Configuration.GetSection("Db").Get<DatabaseConfig>();
                services.AddDbContext<EdusentContext>(options =>
                    options.UseSqlServer(databaseConfig.Connection));
            }

            // Automatically perform database migration
            services.BuildServiceProvider().GetService<EdusentContext>().Database.Migrate();

            services.AddDefaultIdentity<User>()
            .AddEntityFrameworkStores<EdusentContext>()
            .AddDefaultTokenProviders();

            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IUserRepo, UserRepo>();
            //services.AddScoped<ITeacherRepo, TeacherRepo>();
            //services.AddScoped<IStudentRepo, StudentRepo>();
            services.AddScoped<ISessionRepo, SessionRepo>();
            services.AddScoped<IRatingRepo, RatingRepo>();
            

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                // If the LoginPath isn't set, ASP.NET Core defaults
                // the path to /Account/Login.
                options.LoginPath = "/Account/Login";
                // If the AccessDeniedPath isn't set, ASP.NET Core defaults
                // the path to /Account/AccessDenied.
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            //required
            // return 401 instead of not found when user is not logged in
            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, EdusentContext context)
        {

            
            if (env.IsDevelopment() )
            {
                DbInitializer.InitializeData(context);
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
                app.UseDatabaseErrorPage();

            }
            else
            {
                app.UseHsts();
            }

            

            app.UseHttpsRedirection();

            app.UseCors(AllowAnywhere);

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
