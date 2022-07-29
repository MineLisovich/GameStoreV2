using GameStore.Domain;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GameStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Threading.Tasks;

using System;

namespace GameStore.Areas.Admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
       
     

        private readonly UserManager<IdentityUser> userManager;
        private readonly DataManager dataManager;
        private readonly AppDbContext _db;
        public HomeController(DataManager dataManager, AppDbContext db, UserManager<IdentityUser> userMgr)
        {
            this.dataManager = dataManager;
            _db = db;
            userManager = userMgr;
       
        }

        public IActionResult Index()
        {
            return View();
        }
       
        [HttpGet]
        public  IActionResult AllGames( string name)
        {
            IQueryable<AllGames> allGames = _db.AllGames.Include(g => g.Ganres).Include(dev => dev.Developers).Include(p => p.Platforms);
            if (!String.IsNullOrEmpty(name))
            {
                allGames = allGames.Where(p => p.nameGame.Contains(name));
            }
            AllGamesViewModel viewModel = new AllGamesViewModel
            {
                allGames = allGames.ToList(),
                Name = name
            };
            return View(viewModel);
          
        }
        [HttpGet]
        public IActionResult Developers(string name)
        {
            IQueryable<Developers> dev = dataManager.Developers.GetDevelopers();
            if (!String.IsNullOrEmpty(name))
            {
                dev = dev.Where(d => d.nameDeveloper.Contains(name));
            }
            DevelopersViewModel viewModel = new DevelopersViewModel
            {
                developers = dev.ToList(),
                Name = name
            };
            return View(viewModel);

        }
        public IActionResult Ganres(string name)
        {
           IQueryable<Ganres> ganres = dataManager.Ganres.GetGanres();
            if (!String.IsNullOrEmpty(name))
            { 
                ganres = ganres.Where(d => d.nameGanres.Contains(name));
            }
            GanresViewModel viewModel = new GanresViewModel
            { 
             ganres=ganres.ToList(),
             Name = name
            };
            return View(viewModel);
        }
        public IActionResult Platforms(string name)
        {
           IQueryable <Platforms> platforms = dataManager.Platforms.GetPlatforms();
            if (!String.IsNullOrEmpty(name))
            {
                platforms = platforms.Where(p => p.namePlatform.Contains(name));
            }
            PlatfomsViewModel viewModel = new PlatfomsViewModel
            {
                platforms = platforms.ToList(),
                Name = name
            };
            return View(viewModel);
        }

        public IActionResult Shares(string name)
        {
            IQueryable<Shares> shares = _db.Shares.Include(a => a.AllGames);
            if (!String.IsNullOrEmpty(name))
            {
                shares = shares.Where(s => s.AllGames.nameGame.Contains(name));
            }
            SharesViewModel viewModel = new SharesViewModel
            {
                shares = shares.ToList(),
                Name = name
            };
            return View(viewModel);
        }

        public IActionResult Users(string name)
        {
            IEnumerable<IdentityUser> user =  userManager.Users.ToList();
            if (!String.IsNullOrEmpty(name))
            {
                user = user.Where(u => u.UserName.Contains(name));
            }
            UserViewModel viewModel = new UserViewModel
            {
                user = user.ToList(),
                Name = name
            };
            return View(viewModel);
        }

        public IActionResult GameKey(string name)
        {
            IQueryable<GameKey> gameKeys = _db.GameKey.Include(a => a.AllGames);
            if (!String.IsNullOrEmpty(name))
            {
                gameKeys = gameKeys.Where(p => p.AllGames.nameGame.Contains(name));
            }
           GameKeyViewModel viewModel = new GameKeyViewModel
           {
               gameKey = gameKeys,
                Name = name
            };
            return View(viewModel);
        }

        public IActionResult Basket()
        {
            var basket = _db.Basket.Include(a => a.GameKey).Include(u => u.User);
            return View(basket.ToList());   
        }
     
    }
}
