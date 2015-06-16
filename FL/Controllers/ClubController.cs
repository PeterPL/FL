using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Domain.EF;

namespace FL.Controllers
{
    public class ClubController : Controller
    {
        private FootballContext db = new FootballContext();

        // GET: /Club/
        public ActionResult Index()
        {
            return View(db.Clubs.ToList());
        }

        public ActionResult ShowTable()
        {
            return View(db.Clubs.ToList());
        }

       

        // GET: /Club/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.Clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            List<Match> matches = new List<Match>();
            matches = db.Matches.Where(m => m.HomeClubId == id || m.AwayClubId == id).ToList();
            ViewBag.ClubMatches = matches;
            return View(club);
        }

        

        // GET: /Club/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Club/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ClubId,Name,Played,Points,Won,Drawn,Lost,GoalsFor,GoalsAgainst")] Club club)
        {
            if (ModelState.IsValid)
            {
                db.Clubs.Add(club);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(club);
        }

        // GET: /Club/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.Clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // POST: /Club/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ClubId,Name,Played,Points,Won,Drawn,Lost,GoalsFor,GoalsAgainst")] Club club)
        {
            if (ModelState.IsValid)
            {
                db.Entry(club).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(club);
        }

        // GET: /Club/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.Clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // POST: /Club/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Club club = db.Clubs.Find(id);
            List<Match> matches = db.Matches.Where(m => m.HomeClubId == club.ClubId || m.AwayClub.ClubId == club.ClubId).ToList();
            List<Player> players = db.Players.Where(p => p.ClubId == club.ClubId).ToList();
            db.Matches.RemoveRange(matches);
            db.Players.RemoveRange(players);
           // db.Matches.RemoveRange(db.Matches.Where(m => m.HomeClub == club || m.AwayClub == club));
            db.Clubs.Remove(club);
          
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
