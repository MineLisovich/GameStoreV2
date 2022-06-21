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

namespace GameStore.Areas.Admin.Controllers
{
    [Area("admin")]
    public class GanresController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly AppDbContext _db;
        public GanresController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, AppDbContext db)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            _db = db;
        }
    
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ganres = id == default ? new Ganres() : dataManager.Ganres.GetGanresByid(id);
            return View(ganres);
        }
        [HttpPost]
        public IActionResult Edit(Ganres model)
        {

            if (model.nameGanres != null)
            {

                dataManager.Ganres.SaveGanres(model);
                return RedirectToAction(nameof(HomeController.Ganres), nameof(HomeController).CutController());
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(Ganres model)
        {

            dataManager.Ganres.DeleteGanres(model.id);
            return RedirectToAction(nameof(HomeController.Ganres), nameof(HomeController).CutController());
        }
    }
}
