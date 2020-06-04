using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheerSport.Models;
using CheerSport.DAL;
using Microsoft.EntityFrameworkCore;

namespace CheerSport.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (var db=new Context())
            {
                db.Category.Load();
                db.Club.Load();
                db.Competition.Load();
                db.Judge.Load();
                db.JudgeCategory.Load();
                db.JudgeCompetition.Load();
                db.JudgePosition.Load();
                db.SportCategory.Load();
                db.SportRang.Load();
                db.Sportsmen.Load();
                db.Team.Load();
                db.Trainer.Load();
                db.UnionRK.Load();
                var model = db.UnionRK.First();
                return View(model);


            }

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
    }
}
