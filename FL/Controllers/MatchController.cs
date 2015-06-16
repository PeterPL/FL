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
    public class MatchController : Controller
    {
        private FootballContext db = new FootballContext();

        // GET: /Match/
        public ActionResult Index()

        {
            //ViewBag.Clubs = db.Clubs.ToList();
            return View(db.Matches.ToList());
        }

        // GET: /Match/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // GET: /Match/Create
        public ActionResult Create()
        {
            ViewBag.HomeClubId = new SelectList(db.Clubs, "ClubId", "Name");
            ViewBag.AwayClubId = new SelectList(db.Clubs, "ClubId", "Name");
            return View();
        }

        // POST: /Match/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MatchId,HomeGoals,AwayGoals,HomeClubId,AwayClubId")] Match match)
        {
            if (ModelState.IsValid)
            {

                Club home = db.Clubs.Find(match.HomeClubId);
                Club away = db.Clubs.Find(match.AwayClubId);

                home.GoalsFor += match.HomeGoals;
                home.GoalsAgainst += match.AwayGoals;
                away.GoalsFor += match.AwayGoals;
                away.GoalsAgainst += match.HomeGoals;
                home.Played++;
                away.Played++;
 
                //home.Matches.Add(match);
                //away.Matches.Add(match);

                if (match.HomeGoals > match.AwayGoals)
                {
                    home.Won++;
                    away.Lost++;
                    home.Points += 3;
                }
                if (match.HomeGoals < match.AwayGoals)
                {
                    away.Won++;
                    home.Lost++;
                    away.Points += 3;
                }
                if(match.HomeGoals == match.AwayGoals)
                {
                    home.Drawn++;
                    away.Drawn++;
                    home.Points++;
                    away.Points++;
                }

                match.HomeClub = home;
                match.AwayClub = away;

                db.Entry(home).State = EntityState.Modified;
                db.Entry(away).State = EntityState.Modified;
                db.Matches.Add(match);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HomeClubId = new SelectList(db.Clubs, "ClubId", "Name", match.HomeClubId);
            ViewBag.AwayClubId = new SelectList(db.Clubs, "ClubId", "Name",match.AwayClubId);
            return View(match);
        }

        // GET: /Match/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            ViewBag.HomeClubId = new SelectList(db.Clubs, "ClubId", "Name");
            ViewBag.AwayClubId = new SelectList(db.Clubs, "ClubId", "Name");
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // POST: /Match/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MatchId,HomeGoals,AwayGoals,HomeClubId,AwayClubId")] Match match)
        {
            if (ModelState.IsValid)
            {
                db.Entry(match).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(match);
        }

        // GET: /Match/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // POST: /Match/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Match match = db.Matches.Find(id);
            db.Matches.Remove(match);
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
