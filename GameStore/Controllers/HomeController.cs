﻿using GameStore.Domain;
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
using GameStore.Service;
using Microsoft.CodeAnalysis;
using System.Xml.Linq;

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

        public  IActionResult Index()
        {
            var allgames =  dataManager.AllGames.GetAllGames();
            var shares = dataManager.Shares.GetShares();
            AllGamesViewModel viewModel = new AllGamesViewModel
            {
                allGames = allgames.ToList(),
                shares = shares.ToList(),
               
            };
            return View(viewModel);
        }
       
      
        public IActionResult AllGame(string name, int? ganre, int? platfoms, int? developres, int price_from, int price_before)
        {
            var allgames = dataManager.AllGames.GetAllGames();

            // фильтрация игр
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
            if (price_from != 0  && price_before != 0)
            {
                allgames = allgames.Where(p => p.price <= price_before && p.price >= price_from);
            }
            if (price_from > 0 && price_before == 0)
            {
                allgames = allgames.Where(p =>  p.price >= price_from);
            }
            if (price_from == 0  && price_before > 0)
            {
                allgames = allgames.Where(p => p.price <= price_before);
            }
            List<Ganres> ganres = dataManager.Ganres.GetGanres().ToList();
            List<Platforms> platforms = dataManager.Platforms.GetPlatforms().ToList();
            List<Developers> developers = dataManager.Developers.GetDevelopers().ToList();
            ganres.Insert(0, new Ganres { nameGanres = "Жанр", id = 0 });
            platforms.Insert(0, new Platforms { namePlatform = "Платформа", id = 0 });
            developers.Insert(0, new Developers { nameDeveloper = "Разработчик", id = 0 });

            var shares = dataManager.Shares.GetShares();

            AllGamesViewModel viewModel = new AllGamesViewModel
            {
                allGames = allgames.ToList(),
                GanresList = new SelectList(ganres,"id","nameGanres"),
                PlatfomsList = new SelectList(platforms,"id", "namePlatform"),
                DevelopersList = new SelectList(developers,"id", "nameDeveloper"),
                Name = name,
                shares = shares.ToList(),
                from = price_from,
                before = price_before
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Support()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Support(FeedbackViewModel model)
        {
            EmailService emailService = new EmailService();
          
            if (model.user_email != null || model.message != null)
            {
                await emailService.SendEmailAsync("deelimpay@mail.ru", model.user_email, model.message);
                return View("MessageSent"); 
            }
            return View(model);
        }


        public IActionResult Shares(string name, int? ganre, int? platfoms, int? developres, int price_from, int price_before)
        {
            var shares = dataManager.Shares.GetShares();

            // фильтрация игр
            if (ganre != null && ganre != 0)
            {
                shares = shares.Where(g => g.AllGames.Ganresid == ganre);
            }
            if (platfoms != null && platfoms != 0)
            {
                shares = shares.Where(p => p.AllGames.Platformsid == platfoms);
            }
            if (developres != null && developres != 0)
            {
                shares = shares.Where(d => d.AllGames.Developersid == developres);
            }
            if (!String.IsNullOrEmpty(name))
            {
                shares = shares.Where(a => a.AllGames.nameGame.Contains(name));
            }
            if (price_from != 0 && price_before != 0)
            {
                shares = shares.Where(p => p.discountPrice <= price_before && p.discountPrice >= price_from);
            }
            if (price_from > 0 && price_before == 0)
            {
                shares = shares.Where(p => p.discountPrice >= price_from);
            }
            if (price_from == 0 && price_before > 0)
            {
                shares = shares.Where(p => p.discountPrice <= price_before);
            }

            List<Ganres> ganres = _db.Ganres.ToList();
            List<Platforms> platforms = _db.Platforms.ToList();
            List<Developers> developers = _db.Developers.ToList();
            ganres.Insert(0, new Ganres { nameGanres = "Жанр", id = 0 });
            platforms.Insert(0, new Platforms { namePlatform = "Платформа", id = 0 });
            developers.Insert(0, new Developers { nameDeveloper = "Разработчик", id = 0 });

            AllGamesViewModel viewModel = new AllGamesViewModel
            {

                shares = shares.ToList(),
                GanresList = new SelectList(ganres, "id", "nameGanres"),
                PlatfomsList = new SelectList(platforms, "id", "namePlatform"),
                DevelopersList = new SelectList(developers, "id", "nameDeveloper"),
                Name = name,
                from = price_from,
                before = price_before
            };
            return View(viewModel);
        }
        [HttpGet]
        public  IActionResult SinglePageGame(int id)
        {
            var allgames = dataManager.AllGames.GetAllGames();
            var shares = dataManager.Shares.GetShares();
            AllGamesViewModel viewModel = new AllGamesViewModel
            {
                allGames = allgames.ToList(),
                shares = shares.ToList(),
            };
            return View(viewModel);
        }
        public IActionResult ConfirmEmail()
        { 
            return View();
        }
    }
}
