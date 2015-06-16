using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.EF;
using Domain.Entities;

namespace FL.Controllers
{
    public class HomeController : Controller
    {
        private FootballContext db = new FootballContext();
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ViewResult ResetLeague()
        {
            db.Matches.RemoveRange(db.Matches.ToList());
            List<Club> clubs = db.Clubs.ToList();
            for (int i=0; i< clubs.Count(); i++)
            {
                clubs[i].Drawn = 0; clubs[i].Lost = 0; clubs[i].Won = 0; clubs[i].GoalsAgainst = 0; clubs[i].GoalsFor = 0;
                clubs[i].Played = 0; clubs[i].Points = 0; 
            }
            
            db.SaveChanges();
            return View("Index");
        }
    }
}