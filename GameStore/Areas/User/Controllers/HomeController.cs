﻿using System;
using GameStore.Domain;
using GameStore.Domain.Entities;
using GameStore.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using GameStore.Models;
using Microsoft.AspNetCore.Authorization;
using GameStore.Domain.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Collections.Generic;


namespace GameStore.Areas.User.Controllers
{
    [Area ("user")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        private readonly DataManager dataManager;
        UserManager<IdentityUser> _userManager;
        public HomeController(DataManager dataManager, AppDbContext db, UserManager<IdentityUser> userManager)
        {
            this.dataManager = dataManager;
            _db = db;
            _userManager = userManager;
        }
        public async Task<IActionResult> IndexAsync()
        {
           
            var user = await _userManager.GetUserAsync(User);
            IQueryable<Basket> basket = _db.Basket.Include(a => a.GameKey).ThenInclude(g => g.AllGames).Include(u => u.User);
            IQueryable<Cheque> cheque = _db.Cheque.Include(a => a.Basket);

            var TotalPrise = _db.Basket.Include(a => a.GameKey).ThenInclude(g => g.AllGames).Include(u => u.User).Sum(fp => fp.finalPrice);

            UserProfilViewModel viewModel = new UserProfilViewModel
            {
               basket = basket.ToList(),
               cheque = cheque.ToList(),
               identityUser = user,
               totalPrice = TotalPrise
              
        };
           


            return View(viewModel);
        }
    }
}
