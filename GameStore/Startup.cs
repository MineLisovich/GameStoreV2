using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Domain;
using GameStore.Domain.Entities;
using GameStore.Domain.Repositories;
using GameStore.Domain.Repositories.Abstract;
using GameStore.Domain.Repositories.EntityFramework;
using GameStore.Service;


namespace GameStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }  
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public void ConfigureServices(IServiceCollection services)
        {
            // подключаем конфиг из appsettings.json
                 Configuration.Bind("Project", new Config());
            // подключаем нужный функционал 
            services.AddTransient<IAllGamesRepository, EFAllGamesRepository>();
            services.AddTransient<IBasketRepository, EFBasketRepository>();
            services.AddTransient<IDevelopersRepository, EFDevelopersRepository>();
            services.AddTransient<IGanresRepository, EFGanresRepository>();
            services.AddTransient<IPlatformsRepository, EFPlatformsRepository>();
            services.AddTransient<ISharesRepository, EFSharesRepository>();
            services.AddTransient<IGameKeyRepository, EFGameKeyRepository>();
            services.AddTransient<IChekRepository, EFChekRepository>();
            //services.AddTransient<IUsersRepository, EFUsersRepository>();
            services.AddTransient<DataManager>();
            services.AddTransient<EmailService>();
   


            // подключение БД
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            //настраиваем identity систему
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            // куки
            //настраиваем authentication cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "GameStoreCookie";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/login";
                options.SlidingExpiration = true;
            });
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy =>
                {
                    policy.RequireRole("admin");
                });
             x.AddPolicy("UserArea", policy =>
                {
                    policy.RequireRole("user");
              });
            });
            //поддержка контроллеров и представлений (MVC)
            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
                x.Conventions.Add(new UserAreaAuthorization("User", "UserArea"));
            })
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("User", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");           
                endpoints.MapControllerRoute("AllGame", "{controller=Home}/{action=AllGame}");
                endpoints.MapControllerRoute("Action", "{controller=Home}/{action=Action}");
                endpoints.MapControllerRoute("Support", "{controller=Home}/{action=Support}");
            });
        }
    }
}
