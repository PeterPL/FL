﻿using System;
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
    public class PlayerController : Controller
    {
        private FootballContext db = new FootballContext();

        // GET: /Player/
        public ActionResult Index()
        {
            var players = db.Players.Include(p => p.Club).Include(p => p.Position);
            return View(players.ToList());
        }


        // GET: /Player/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: /Player/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ClubId = new SelectList(db.Clubs, "ClubId", "Name");
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "Name");
            return View();
        
        }
        [Authorize]
        public ActionResult CreateByClub(int clubId)
        {
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "Name");
            ViewBag.ClubId = clubId;
            return View();
        }

        // POST: /Player/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PlayerId,Name,PositionId,ClubId")] Player player)
        {
            if (ModelState.IsValid)
            {
                player.Club = db.Clubs.FirstOrDefault(c => c.ClubId == player.ClubId);
                player.Position = db.Positions.FirstOrDefault(p => p.PositionId == player.PositionId);
                db.Players.Add(player);
                Club club = player.Club;
                club.Players.Add(player);
                db.Entry(club).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClubId = new SelectList(db.Clubs, "ClubId", "Name", player.ClubId);
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "Name", player.PositionId);
            return View(player);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult CreateByClub([Bind(Include = "PlayerId,Name,PositionId,ClubId")] Player player)
        {
            if (ModelState.IsValid)
            {
                player.Club = db.Clubs.FirstOrDefault(c => c.ClubId == player.ClubId);
                player.Position = db.Positions.FirstOrDefault(p => p.PositionId == player.PositionId);
                db.Players.Add(player);
                Club club = player.Club;
                club.Players.Add(player);
                db.Entry(club).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Club", new{Id=club.ClubId});
            }

            ViewBag.ClubId = new SelectList(db.Clubs, "ClubId", "Name", player.ClubId);
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "Name", player.PositionId);
            return View(player);
        }

        // GET: /Player/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClubId = new SelectList(db.Clubs, "ClubId", "Name", player.ClubId);
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "Name", player.PositionId);
            return View(player);
        }

        // POST: /Player/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PlayerId,Name,PositionId,ClubId")] Player player)
        {
            if (ModelState.IsValid)
            {

                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClubId = new SelectList(db.Clubs, "ClubId", "Name", player.ClubId);
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "Name", player.PositionId);
            return View(player);
        }

        // GET: /Player/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: /Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
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
