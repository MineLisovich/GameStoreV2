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
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Http.Features;

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
        public async Task<IActionResult> Add(int id)
        {
            Basket model = new Basket();
            var user = await _userManager.GetUserAsync(User);
            var allgames = _db.AllGames.FirstOrDefault(a => a.id == id);
            var shares = _db.Shares.Where(s=>s.AllGamesid==id).ToList();

            foreach (var sh in shares)
            {
                if (sh.AllGamesid == allgames.id)
                {

                    model.AllGamesid = allgames.id;
                    model.finalPrice = sh.discountPrice;
                    model.UserId = user.Id;

                    if (model.AllGamesid != 0 && model.UserId != null)
                    {
                        dataManager.Basket.SaveBasket(model);
                        return RedirectToAction("Index", "Home");
                    }
                }           
            }
            if (shares.Count()==0)
            {


                model.AllGamesid = allgames.id;
                model.finalPrice = allgames.price;
                model.UserId = user.Id;

                if (model.AllGamesid != 0 && model.UserId != null)
                {
                    dataManager.Basket.SaveBasket(model);
                    return RedirectToAction("Index", "Home");
                }
            }


            return View(model);
        }
    }
}
