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
    public class EventController : Controller
    {
        private FootballContext db = new FootballContext();

        // GET: /Event/
        /*public ActionResult Index()
        {
            var events = db.Events.Include(@ => @.Club).Include(@ => @.Kind).Include(@ => @.Match).Include(@ => @.Player);
            return View(events.ToList());
        }*/

        // GET: /Event/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: /Event/Create
        public ActionResult Create()
        {
            ViewBag.ClubId = new SelectList(db.Clubs, "ClubId", "Name");
            ViewBag.EventKindId = new SelectList(db.EventKinds, "EventKindId", "Name");
            ViewBag.MatchId = new SelectList(db.Matches, "MatchId", "MatchId");
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "FirstName");
            return View();
        }

        // POST: /Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EventId,Time,MatchId,ClubId,PlayerId,EventKindId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClubId = new SelectList(db.Clubs, "ClubId", "Name", @event.ClubId);
            ViewBag.EventKindId = new SelectList(db.EventKinds, "EventKindId", "Name", @event.EventKindId);
            ViewBag.MatchId = new SelectList(db.Matches, "MatchId", "MatchId", @event.MatchId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "FirstName", @event.PlayerId);
            return View(@event);
        }

        // GET: /Event/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClubId = new SelectList(db.Clubs, "ClubId", "Name", @event.ClubId);
            ViewBag.EventKindId = new SelectList(db.EventKinds, "EventKindId", "Name", @event.EventKindId);
            ViewBag.MatchId = new SelectList(db.Matches, "MatchId", "MatchId", @event.MatchId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "FirstName", @event.PlayerId);
            return View(@event);
        }

        // POST: /Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EventId,Time,MatchId,ClubId,PlayerId,EventKindId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClubId = new SelectList(db.Clubs, "ClubId", "Name", @event.ClubId);
            ViewBag.EventKindId = new SelectList(db.EventKinds, "EventKindId", "Name", @event.EventKindId);
            ViewBag.MatchId = new SelectList(db.Matches, "MatchId", "MatchId", @event.MatchId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "FirstName", @event.PlayerId);
            return View(@event);
        }

        // GET: /Event/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: /Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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