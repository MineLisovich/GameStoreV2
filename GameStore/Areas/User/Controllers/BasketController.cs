using System;
using GameStore.Domain;
using GameStore.Domain.Entities;
using GameStore.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using GameStore.Models;
using Microsoft.AspNetCore.Authorization;
using GameStore.Domain.Repositories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace GameStore.Areas.User.Controllers
{
    [Area("User")]
    public class BasketController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly AppDbContext _db;
        UserManager<IdentityUser> _userManager;

        public BasketController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, AppDbContext db,UserManager<IdentityUser> userManager)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Delete(Basket model)
        {
            dataManager.Basket.DeleteBasket(model.id);
            return RedirectToAction(nameof(Index), nameof(HomeController).CutController());
        }
        [HttpGet]
        public IActionResult Add(Basket model,int id)
        {
            var allGames = id == default ? new AllGames() : dataManager.AllGames.GetAllGamesByid(id);

            model.AllGamesid = allGames.id;
            model.amount = 1;
            model.finalPrice = 22;
            model.UserId = "702";

            if (model.AllGamesid != 0)
            {
                dataManager.Basket.SaveBasket(model);
                return RedirectToAction("Index", "Home");
            }
           
            return View(model);
        }
    }
}
