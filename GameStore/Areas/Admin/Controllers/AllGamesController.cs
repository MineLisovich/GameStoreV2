
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
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GameStore.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AllGamesController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly AppDbContext _db;
       
        public AllGamesController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, AppDbContext db)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            _db = db;
        }

        [HttpGet]
       
        public IActionResult Edit(int id)
        {

            var allGames = id == default ? new AllGames() : dataManager.AllGames.GetAllGamesByid(id);
            var developers = dataManager.Developers.GetDevelopersByid(allGames.Developersid);
            var platforms = dataManager.Platforms.GetPlatformsByid(allGames.Platformsid);
            var ganres = dataManager.Ganres.GetGanresByid(allGames.Ganresid);
         
            SelectList GanreDropList = new SelectList(_db.Ganres, "nameGanres", "nameGanres");
            ViewBag.GanresList = GanreDropList;

            SelectList DevelopersDropList = new SelectList(_db.Developers, "nameDeveloper", "nameDeveloper");
            ViewBag.DevelopersList = DevelopersDropList;

            SelectList PlatformsDropList = new SelectList(_db.Platforms, "namePlatform", "namePlatform");
            ViewBag.PlatformsList = PlatformsDropList;

            return View(allGames);
        }

        [HttpPost]
        public IActionResult Edit(AllGames model, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    model.Poster = imageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/product", imageFile.FileName), FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }
                   
                }
                var DevelopersByCodeWord = dataManager.Developers.GetDevelopersByCodeWord(model.Developers.nameDeveloper);
                var PlatformsByCodeWord = dataManager.Platforms.GetPlatformsByCodeWord(model.Platforms.namePlatform);
                var GanresByCodeWord = dataManager.Ganres.GetGanresByCodeWord(model.Ganres.nameGanres);
                if (DevelopersByCodeWord != null && PlatformsByCodeWord != null && GanresByCodeWord != null)
                {
                    model.Developersid = DevelopersByCodeWord.id;
                    model.Platformsid = PlatformsByCodeWord.id;
                    model.Ganresid = GanresByCodeWord.id;                  
                    dataManager.AllGames.SaveAllGames(model);
                    return RedirectToAction(nameof(HomeController.AllGames), nameof(HomeController).CutController());
                }
            }


           
           
            return View(model);
        }


           
        

        [HttpGet]
        public IActionResult Delete(AllGames model)
        {
         
          dataManager.AllGames.DeleteAllGames(model.id);
         return RedirectToAction(nameof(HomeController.AllGames), nameof(HomeController).CutController());
        }

    }
}
