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
    public class DevelopersController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly AppDbContext _db;
        public DevelopersController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, AppDbContext db)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            _db = db;
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var developers = id == default ? new Developers() : dataManager.Developers.GetDevelopersByid(id);
            return View(developers);
        }
        [HttpPost]
        public IActionResult Edit(Developers model)
        {
            
            if (model.nameDeveloper != null )
            {
               
                dataManager.Developers.SaveDevelopers(model);
                return RedirectToAction(nameof(HomeController.Developers), nameof(HomeController).CutController());
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(Developers model)
        {

            dataManager.Developers.DeleteDevelopers(model.id);
            return RedirectToAction(nameof(HomeController.Developers), nameof(HomeController).CutController());
        }
    }
}
