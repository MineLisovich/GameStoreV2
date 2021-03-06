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
using System.Threading.Tasks;
using System;

namespace GameStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        private readonly DataManager dataManager;
        public HomeController(DataManager dataManager, AppDbContext db)
        {
            this.dataManager = dataManager;
            _db = db;
        }

        public IActionResult Index()
        {
            IQueryable<AllGames> allgames = _db.AllGames.Include(g => g.Ganres).Include(d => d.Developers).Include(p => p.Platforms);
            IQueryable<Shares> shares = _db.Shares.Include(a => a.AllGames);
            AllGamesViewModel viewModel = new AllGamesViewModel
            {
                allGames = allgames.ToList(),
                shares = shares.ToList(),
               
            };
            return View(viewModel);
        }
       
      
        public IActionResult AllGame(string name, int? ganre, int? platfoms, int? developres)
        {
            IQueryable<AllGames> allgames = _db.AllGames.Include(g => g.Ganres).Include(d => d.Developers).Include(p => p.Platforms);
            if (ganre != null && ganre!=0)
            {
                allgames = allgames.Where(g=>g.Ganresid==ganre);
            }
            if (platfoms != null && platfoms != 0)
            {
                allgames = allgames.Where(p => p.Platformsid == platfoms);
            }
            if (developres != null && developres != 0)
            {
                allgames = allgames.Where(d => d.Developersid == developres);
            }
            if (!String.IsNullOrEmpty(name))
            {
                allgames = allgames.Where(a => a.nameGame.Contains(name));
            }


            List<Ganres> ganres = _db.Ganres.ToList();
            List<Platforms> platforms = _db.Platforms.ToList();
            List<Developers> developers = _db.Developers.ToList();
            ganres.Insert(0, new Ganres { nameGanres = "Жанр", id = 0 });
            platforms.Insert(0, new Platforms { namePlatform = "Платформа", id = 0 });
            developers.Insert(0, new Developers { nameDeveloper = "Разработчик", id = 0 });

            AllGamesViewModel viewModel = new AllGamesViewModel
            {
                allGames = allgames.ToList(),
                GanresList = new SelectList(ganres,"id","nameGanres"),
                PlatfomsList = new SelectList(platforms,"id", "namePlatform"),
                DevelopersList = new SelectList(developers,"id", "nameDeveloper"),
                Name = name
            };
            return View(viewModel);
        }
    
        public IActionResult Support()
        {
            return View();
        }


        public IActionResult Shares(string name, int? ganre, int? platfoms, int? developres)
        {
            IQueryable<AllGames> allgames = _db.AllGames.Include(g => g.Ganres).Include(d => d.Developers).Include(p => p.Platforms);
            IQueryable<Shares> shares = _db.Shares.Include(a => a.AllGames);
            if (ganre != null && ganre != 0)
            {
                allgames = allgames.Where(g => g.Ganresid == ganre);
            }
            if (platfoms != null && platfoms != 0)
            {
                allgames = allgames.Where(p => p.Platformsid == platfoms);
            }
            if (developres != null && developres != 0)
            {
                allgames = allgames.Where(d => d.Developersid == developres);
            }
            if (!String.IsNullOrEmpty(name))
            {
                allgames = allgames.Where(a => a.nameGame.Contains(name));
            }


            List<Ganres> ganres = _db.Ganres.ToList();
            List<Platforms> platforms = _db.Platforms.ToList();
            List<Developers> developers = _db.Developers.ToList();
            ganres.Insert(0, new Ganres { nameGanres = "Жанр", id = 0 });
            platforms.Insert(0, new Platforms { namePlatform = "Платформа", id = 0 });
            developers.Insert(0, new Developers { nameDeveloper = "Разработчик", id = 0 });

            AllGamesViewModel viewModel = new AllGamesViewModel
            {
                allGames = allgames.ToList(),
                shares = shares.ToList(),
                GanresList = new SelectList(ganres, "id", "nameGanres"),
                PlatfomsList = new SelectList(platforms, "id", "namePlatform"),
                DevelopersList = new SelectList(developers, "id", "nameDeveloper"),
                Name = name
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult SinglePageGame(int id)
        {
            var allGames = id == default ? new AllGames() : dataManager.AllGames.GetAllGamesByid(id);
            var developers = dataManager.Developers.GetDevelopersByid(allGames.Developersid);
            var platforms = dataManager.Platforms.GetPlatformsByid(allGames.Platformsid);
            var ganres = dataManager.Ganres.GetGanresByid(allGames.Ganresid);
            return View(allGames);
        }

    }
}
