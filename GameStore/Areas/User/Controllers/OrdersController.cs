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
    public class OrdersController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly AppDbContext _db;
        UserManager<IdentityUser> _userManager;

        public OrdersController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, AppDbContext db, UserManager<IdentityUser> userManager)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            _db = db;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Order()
        {
            var user = await _userManager.GetUserAsync(User);
            IQueryable<Basket> basket = _db.Basket.Include(g => g.AllGames).Include(u => u.User);
            IQueryable<Chek> cheque = _db.Chek.Include(a => a.User).Include(g => g.GameKey);

            var TotalPrise = _db.Basket.Include(g => g.AllGames).Include(u => u.User).Where(us => us.UserId == user.Id).Sum(fp => fp.finalPrice);

            UserProfilViewModel viewModel = new UserProfilViewModel
            {
                basket = basket.ToList(),
                Chek = cheque.ToList(),
                identityUser = user,
                totalPrice = TotalPrise

            };



            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Payment()
        {
            var user = await _userManager.GetUserAsync(User);
            var basket = _db.Basket.Include(g => g.AllGames).Include(u => u.User).Where(us => us.UserId == user.Id).ToList();
            var gameKey = _db.GameKey.Include(all => all.AllGames).ToList();

            
           

            for (int i = 0; i < basket.Count(); i++)
            {
                for (int j = 0; j < gameKey.Count(); j++)
                {

                    if (basket[i].AllGames.nameGame == gameKey[j].AllGames.nameGame)
                    {


                        Chek model = new Chek()
                        {
                            dateAddedCheque = DateTime.Now,
                            UserId = basket[i].UserId,
                            nameGame = basket[i].AllGames.nameGame,
                            priceGame = basket[i].AllGames.price,
                            GameKeyid = gameKey[j].id,

                        };
                        dataManager.Chek.SaveChek(model);
                    }
                    else
                    {
                        return View("OrderError");
                    }
                }
            }
                var query = from c in basket select c;
            foreach (Basket basket1 in query)
            { 
                _db.Basket.Remove(basket1);
            }
            _db.SaveChanges();
            return View("OrderSucceeded");
        }
        public async Task<IActionResult> MyOrders()
        {

            var user = await _userManager.GetUserAsync(User);
            IQueryable<Basket> basket = _db.Basket.Include(g => g.AllGames).Include(u => u.User);
            IQueryable<Chek> cheque = _db.Chek.Include(a => a.User).Include(g => g.GameKey);

            var TotalPrise = _db.Basket.Include(g => g.AllGames).Include(u => u.User).Where(us => us.UserId == user.Id).Sum(fp => fp.finalPrice);

            UserProfilViewModel viewModel = new UserProfilViewModel
            {
                basket = basket.ToList(),
                Chek = cheque.ToList(),
                identityUser = user,
                totalPrice = TotalPrise

            };



            return View(viewModel);
        }

    }
}
