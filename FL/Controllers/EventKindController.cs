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
    public class EventKindController : Controller
    {
        private FootballContext db = new FootballContext();

        // GET: /EventKind/
        public ActionResult Index()
        {
            return View(db.EventKinds.ToList());
        }

        // GET: /EventKind/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventKind eventkind = db.EventKinds.Find(id);
            if (eventkind == null)
            {
                return HttpNotFound();
            }
            return View(eventkind);
        }

        // GET: /EventKind/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /EventKind/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EventKindId,Name")] EventKind eventkind)
        {
            if (ModelState.IsValid)
            {
                db.EventKinds.Add(eventkind);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventkind);
        }

        // GET: /EventKind/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventKind eventkind = db.EventKinds.Find(id);
            if (eventkind == null)
            {
                return HttpNotFound();
            }
            return View(eventkind);
        }

        // POST: /EventKind/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EventKindId,Name")] EventKind eventkind)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventkind).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventkind);
        }

        // GET: /EventKind/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventKind eventkind = db.EventKinds.Find(id);
            if (eventkind == null)
            {
                return HttpNotFound();
            }
            return View(eventkind);
        }

        // POST: /EventKind/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventKind eventkind = db.EventKinds.Find(id);
            db.EventKinds.Remove(eventkind);
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
