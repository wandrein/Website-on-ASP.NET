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
    public class NufusController : Controller
    {
        private ChadDBEntities db = new ChadDBEntities();

        // GET: Nufus
        public ActionResult Index()
        {
            var nufuslars = db.Nufuslars.Include(n => n.Sehirler);
            return View(nufuslars.ToList());
        }

        // GET: Nufus/Details/5
        [Authorize(Users = "f@f.com")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nufus nufus = db.Nufuslars.Find(id);
            if (nufus == null)
            {
                return HttpNotFound();
            }
            return View(nufus);
        }

        // GET: Nufus/Create
        [Authorize(Users = "f@f.com")]
        public ActionResult Create()
        {
            ViewBag.SehirId = new SelectList(db.Sehirlers, "Id", "Isim");
            return View();
        }

        // POST: Nufus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SehirId,Yil,NufusMiktar")] Nufus nufus)
        {
            if (ModelState.IsValid)
            {
                db.Nufuslars.Add(nufus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SehirId = new SelectList(db.Sehirlers, "Id", "Isim", nufus.SehirId);
            return View(nufus);
        }

        // GET: Nufus/Edit/5
        [Authorize(Users = "f@f.com")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nufus nufus = db.Nufuslars.Find(id);
            if (nufus == null)
            {
                return HttpNotFound();
            }
            ViewBag.SehirId = new SelectList(db.Sehirlers, "Id", "Isim", nufus.SehirId);
            return View(nufus);
        }

        // POST: Nufus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SehirId,Yil,NufusMiktar")] Nufus nufus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nufus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SehirId = new SelectList(db.Sehirlers, "Id", "Isim", nufus.SehirId);
            return View(nufus);
        }

        // GET: Nufus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nufus nufus = db.Nufuslars.Find(id);
            if (nufus == null)
            {
                return HttpNotFound();
            }
            return View(nufus);
        }

        // POST: Nufus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nufus nufus = db.Nufuslars.Find(id);
            db.Nufuslars.Remove(nufus);
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
