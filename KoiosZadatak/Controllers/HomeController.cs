using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KoiosZadatak.Models;
using Microsoft.EntityFrameworkCore;

namespace KoiosZadatak.Controllers
{
    public class HomeController : Controller
    {
        private KoiosDbContext db;
        public HomeController(KoiosDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Drzave()
        {
            var model = db.Drzave.ToList();
            return View(model);
        }
        public IActionResult Naselja()
        {
            var nvv = new NaseljeViewModel();
            nvv.Drzave = db.Drzave.ToList();
            nvv.Naselja = db.Naselja.Include("Drzava").ToList();
            return View(nvv);
        }
        [HttpPost]
        public IActionResult UnesiDrzavu(string naziv)
        {
            return Content(naziv);
        }
        [HttpPost]
        public IActionResult UnesiNaselje(Naselje naselje)
        {
            db.Naselja.Add(naselje);
            db.SaveChanges();
            return Content("OK");
        }
    }
}
