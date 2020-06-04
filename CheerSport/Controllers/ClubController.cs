using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheerSport.DAL;
using CheerSport.Models;
using CheerSport.Models.ModelsForView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheerSport.Controllers
{
    public class ClubController : Controller
    {
        public IActionResult ClubView(int id)
        {
            using (var db = new Context())
            {
                var model = new ModelForClubView();
                //db.Category.Load();
                db.Club.Load();
                //db.Competition.Load();
                //db.Judge.Load();
                //db.JudgeCategory.Load();
                //db.JudgeCompetition.Load();
                // db.JudgePosition.Load();
                db.SportCategory.Load();
                db.SportRang.Load();
                db.Sportsmen.Load();
                db.Team.Load();
                db.Trainer.Load();
                //db.UnionRK.Load();
                model.allClubs = db.Club.ToList();
                if (id == -1)
                {
                    
                    model.selectClub = db.Club.ToList()[0].id;
                    model.sportsmenOnClub = db.Sportsmen.Where(x => x.Clubid == model.selectClub).ToList();
                    model.teamOnClub = db.Team.Where(x => x.Clubid == model.selectClub).ToList();
                    model.trainerOnClub = db.Trainer.Where(x => x.Clubid == model.selectClub).ToList();
                    return View(model);

                }
                else
                {
                    
                    model.selectClub = id;
                    model.sportsmenOnClub = db.Sportsmen.Where(x => x.Clubid == model.selectClub).ToList();
                    model.teamOnClub = db.Team.Where(x => x.Clubid == model.selectClub).ToList();
                    model.trainerOnClub = db.Trainer.Where(x => x.Clubid == model.selectClub).ToList();
                    return View(model);

                }
                
            }
        }
        
        public IActionResult ClubInfoView(int id)
        {
            
            using (var db = new Context())
            {
                var model = new ModelForClubView();
                db.Club.Load();
                db.SportCategory.Load();
                db.SportRang.Load();
                db.Sportsmen.Load();
                db.Team.Load();
                db.Trainer.Load();
                model.allClubs = db.Club.ToList();
                model.selectClub = id;
                model.sportsmenOnClub = db.Sportsmen.Where(x => x.Clubid == model.selectClub).ToList();
                model.teamOnClub = db.Team.Where(x => x.Clubid == model.selectClub).ToList();
                model.trainerOnClub = db.Trainer.Where(x => x.Clubid == model.selectClub).ToList();
                return View("ClubView", model);
            }
                
           
        }

      
        //тренера
        public IActionResult TrainerView(int id)
        {
            using (var db = new Context())
            {
                var model = new ModelForTrainerView();
                db.Club.Load();
                db.Trainer.Load();
                model.selectTrainer = db.Trainer.FirstOrDefault(x => x.id == id);
                model.allClub = db.Club.ToList();
                return View(model);


            }
        }
        [HttpGet]
        public IActionResult TrainerEdit(int? id)
        {

            using (var db = new Context())
            {
                var model = new ModelForTrainerView();
                db.Club.Load(); 
                db.Trainer.Load();
                model.selectTrainer = db.Trainer.FirstOrDefault(x => x.id == id);
                model.allClub = db.Club.ToList();
                return View("TrainerEditView", model);
            }

        }
        [HttpPost]
        public IActionResult TrainerEditPost()
        {
            using (var db = new Context())
            {
                int id = int.Parse(Request.Form["selectTrainer.id"]);
                Trainer trainer = db.Trainer.FirstOrDefault(x => x.id == id);
                trainer.name = Request.Form["selectTrainer.name"].ToString();
                trainer.surname = Request.Form["selectTrainer.surname"].ToString();
                trainer.patronymic = Request.Form["selectTrainer.patronymic"].ToString();
                trainer.phone = Request.Form["selectTrainer.phone"].ToString();
                trainer.dateBirth = Convert.ToDateTime(Request.Form["selectTrainer.dateBirth"]);
                trainer.job = Request.Form["selectTrainer.job"].ToString();
                //trainer.photo = Request.Form["selectTrainer.photo"].ToString();
                db.SaveChanges();
                var model = new ModelForTrainerView();
                db.Club.Load();
                db.Trainer.Load();
                model.selectTrainer = db.Trainer.FirstOrDefault(x => x.id == id);
                model.allClub = db.Club.ToList();
                return View("TrainerView", model);
            }
        }

        [HttpPost]
        public IActionResult TrainerDelete(int id)
        {
            Trainer trainer = new Trainer();
            using (var db = new Context())
            {
                trainer = db.Trainer.FirstOrDefault(x => x.id == id);
                db.Trainer.Remove(trainer);
                db.SaveChanges();
                var model = new ModelForClubView();
                db.Club.Load();
                db.SportCategory.Load();
                db.SportRang.Load();
                db.Sportsmen.Load();
                db.Team.Load();
                db.Trainer.Load();
                model.allClubs = db.Club.ToList();
                model.selectClub = trainer.Clubid;
                model.sportsmenOnClub = db.Sportsmen.Where(x => x.Clubid == model.selectClub).ToList();
                model.teamOnClub = db.Team.Where(x => x.Clubid == model.selectClub).ToList();
                model.trainerOnClub = db.Trainer.Where(x => x.Clubid == model.selectClub).ToList();
                return View("ClubView", model);
            }

        }
        [HttpGet]
        public IActionResult TrainerAddView (int id)
        {
            using (var db = new Context())
            {
                db.Club.Load();
                var club = db.Club.FirstOrDefault(x => x.id == id);
                return View(club);

            }

                
        }
        [HttpPost]
        public IActionResult TrainerAddView()
        {
            using (var db = new Context())
            {
                var newTrainer = new Trainer();
                newTrainer.job = Request.Form["job"];
                newTrainer.name = Request.Form["name"];
                newTrainer.surname = Request.Form["surname"];
                newTrainer.patronymic = Request.Form["patronymic"];
                newTrainer.phone = Request.Form["phone"].ToString();
                newTrainer.photo = "";
                newTrainer.dateBirth = Convert.ToDateTime(Request.Form["dateBirth"]);
                newTrainer.Clubid= int.Parse(Request.Form["idClub"]);
                db.Trainer.Add(newTrainer);
                db.SaveChanges();

                var model = new ModelForClubView();
                db.Club.Load();
                db.SportCategory.Load();
                db.SportRang.Load();
                db.Sportsmen.Load();
                db.Team.Load();
                db.Trainer.Load();
                model.allClubs = db.Club.ToList();
                model.selectClub = newTrainer.Clubid;
                model.sportsmenOnClub = db.Sportsmen.Where(x => x.Clubid == model.selectClub).ToList();
                model.teamOnClub = db.Team.Where(x => x.Clubid == model.selectClub).ToList();
                model.trainerOnClub = db.Trainer.Where(x => x.Clubid == model.selectClub).ToList();
                return View("ClubView", model);

            }


        }

        //команды
        public IActionResult TeamView(int id)
        {
            using (var db = new Context())
            {
                var model = new ModelForTeamView();
                db.Club.Load();
                db.Team.Load();
                model.selectTeam = db.Team.FirstOrDefault(x => x.id == id);
                model.allClub = db.Club.ToList();
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult TeamEdit(int? id)
        {

            using (var db = new Context())
            {
                var model = new ModelForTeamView();
                db.Club.Load();
                db.Team.Load();
                model.selectTeam = db.Team.FirstOrDefault(x => x.id == id);
                model.allClub = db.Club.ToList();
                return View("TeamEditView", model);
            }

        }
        [HttpPost]
        public IActionResult TeamEditPost()
        {
            using (var db = new Context())
            {
                int id = int.Parse(Request.Form["selectTeam.id"]);
                Team team = db.Team.FirstOrDefault(x => x.id == id);
                team.name = Request.Form["selectTeam.name"].ToString();
                team.city = Request.Form["selectTeam.city"].ToString();
                db.SaveChanges();
                var model = new ModelForTeamView();
                db.Club.Load();
                db.Team.Load();
                model.selectTeam = db.Team.FirstOrDefault(x => x.id == id);
                model.allClub = db.Club.ToList();
                return View("TeamView", model);
            }
        }

        [HttpPost]
        public IActionResult TeamDelete(int id)
        {
            Team team = new Team();
            using (var db = new Context())
            {
                team = db.Team.FirstOrDefault(x => x.id == id);
                db.Team.Remove(team);
                db.SaveChanges();
                var model = new ModelForClubView();
                db.Club.Load();
                db.SportCategory.Load();
                db.SportRang.Load();
                db.Sportsmen.Load();
                db.Team.Load();
                db.Trainer.Load();
                model.allClubs = db.Club.ToList();
                model.selectClub = team.Clubid;
                model.sportsmenOnClub = db.Sportsmen.Where(x => x.Clubid == model.selectClub).ToList();
                model.teamOnClub = db.Team.Where(x => x.Clubid == model.selectClub).ToList();
                model.trainerOnClub = db.Trainer.Where(x => x.Clubid == model.selectClub).ToList();
                return View("ClubView", model);
            }

        }

        [HttpGet]
        public IActionResult TeamAddView(int id)
        {
            using (var db = new Context())
            {
                db.Club.Load();
                var club = db.Club.FirstOrDefault(x => x.id == id);
                return View(club);

            }


        }
        [HttpPost]
        public IActionResult TeamAddView()
        {
            using (var db = new Context())
            {
                var newTeam = new Team();
                newTeam.city = Request.Form["city"];
                newTeam.name = Request.Form["name"];
                newTeam.Clubid = int.Parse(Request.Form["idClub"]);
                db.Team.Add(newTeam);
                db.SaveChanges();

                var model = new ModelForClubView();
                db.Club.Load();
                db.SportCategory.Load();
                db.SportRang.Load();
                db.Sportsmen.Load();
                db.Team.Load();
                db.Trainer.Load();
                model.allClubs = db.Club.ToList();
                model.selectClub = newTeam.Clubid;
                model.sportsmenOnClub = db.Sportsmen.Where(x => x.Clubid == model.selectClub).ToList();
                model.teamOnClub = db.Team.Where(x => x.Clubid == model.selectClub).ToList();
                model.trainerOnClub = db.Trainer.Where(x => x.Clubid == model.selectClub).ToList();
                return View("ClubView", model);

            }


        }


    }
}