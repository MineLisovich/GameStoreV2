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
    public class GameKeyController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly AppDbContext _db;
        public GameKeyController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, AppDbContext db)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            _db = db;
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var gamekey = id == default ? new GameKey() : dataManager.GameKey.GetGameKeyByid(id);
            var allgame = dataManager.AllGames.GetAllGamesByid(gamekey.AllGamesid);
            SelectList AllGamesList = new SelectList(_db.AllGames,"nameGame","nameGame");
            ViewBag.AllGamesDropList = AllGamesList;
            return View(gamekey);
        }
        [HttpPost]
        public IActionResult Edit(GameKey model)
        {
            var AllgamesByCodeWord = dataManager.AllGames.GetAllGamesByCodeWord(model.AllGames.nameGame);

            if (model.Key_game != null && AllgamesByCodeWord !=null)
            {
                model.AllGamesid = AllgamesByCodeWord.id;
                dataManager.GameKey.SaveGameKey(model);
                return RedirectToAction(nameof(HomeController.GameKey), nameof(HomeController).CutController());
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(GameKey model)
        {

            dataManager.GameKey.DeleteGameKey(model.id);
            return RedirectToAction(nameof(HomeController.GameKey), nameof(HomeController).CutController());
        }

    }
}
