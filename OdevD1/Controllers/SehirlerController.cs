using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OdevD1.Models;

namespace OdevD1.Controllers
{
    [Authorize]
    public class SehirlerController : Controller
    {
        private ChadDBEntities db = new ChadDBEntities();

        // GET: Sehirler
        public ActionResult Index()
        {
            return View(db.Sehirlers.ToList());
        }

        // GET: Sehirler/Details/5
        [Authorize(Users = "f@f.com")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sehirler sehirler = db.Sehirlers.Find(id);
            if (sehirler == null)
            {
                return HttpNotFound();
            }
            return View(sehirler);
        }

        // GET: Sehirler/Create
        [Authorize(Users ="f@f.com")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sehirler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Isim,Nufus,Hakkinda")] Sehirler sehirler)
        {
            if (ModelState.IsValid)
            {
                db.Sehirlers.Add(sehirler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sehirler);
        }

        // GET: Sehirler/Edit/5
        [Authorize(Users = "f@f.com")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sehirler sehirler = db.Sehirlers.Find(id);
            if (sehirler == null)
            {
                return HttpNotFound();
            }
            return View(sehirler);
        }

        // POST: Sehirler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Isim,Nufus,Hakkinda")] Sehirler sehirler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sehirler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sehirler);
        }

        // GET: Sehirler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sehirler sehirler = db.Sehirlers.Find(id);
            if (sehirler == null)
            {
                return HttpNotFound();
            }
            return View(sehirler);
        }

        // POST: Sehirler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sehirler sehirler = db.Sehirlers.Find(id);
            db.Sehirlers.Remove(sehirler);
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
