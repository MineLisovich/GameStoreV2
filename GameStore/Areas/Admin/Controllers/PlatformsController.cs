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


namespace GameStore.Areas.Admin.Controllers
{
    [Area("admin")]
    public class PlatformsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly AppDbContext _db;
        public PlatformsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, AppDbContext db)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            _db = db;
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var platforms = id == default ? new Platforms() : dataManager.Platforms.GetPlatformsByid(id);
            return View(platforms);
        }
        [HttpPost]
        public IActionResult Edit(Platforms model)
        {

            if (model.namePlatform != null)
            {

                dataManager.Platforms.SavePlatforms(model);
                return RedirectToAction(nameof(HomeController.Platforms), nameof(HomeController).CutController());
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(Platforms model)
        {

            dataManager.Platforms.DeletePlatforms(model.id);
            return RedirectToAction(nameof(HomeController.Platforms), nameof(HomeController).CutController());
        }
    }
}
