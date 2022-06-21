using Microsoft.AspNetCore.Mvc;
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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore.Areas.Admin.Controllers
{
    [Area("admin")]
    public class SharesController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly AppDbContext _db;
        public SharesController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, AppDbContext db)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            _db = db;
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var shares = id == default ? new Shares() : dataManager.Shares.GetSharesByid(id);
            SelectList AllGamesList = new SelectList(_db.AllGames, "nameGame", "nameGame");
            ViewBag.AllGamesDropList = AllGamesList;
            return View(shares);
        }
        [HttpPost]
        public IActionResult Edit(Shares model)
        {


            var AllGamesByCodeWord = dataManager.AllGames.GetAllGamesByCodeWord(model.AllGames.nameGame);
         
            if (AllGamesByCodeWord != null)
            {
                model.AllGamesid = AllGamesByCodeWord.id;
              

                dataManager.Shares.SaveShares(model);
                return RedirectToAction(nameof(HomeController.Shares), nameof(HomeController).CutController());
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(Shares model)
        {

            dataManager.Shares.DeleteShares(model.id);
            return RedirectToAction(nameof(HomeController.Shares), nameof(HomeController).CutController());
        }
    }
}
