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
    public class BolgelerController : Controller
    {
        private ChadDBEntities db = new ChadDBEntities();

        // GET: Bolgeler
        public ActionResult Index()
        {
            var bolgelers = db.Bolgelers.Include(b => b.Sehirler);
            return View(bolgelers.ToList());
        }

        // GET: Bolgeler/Details/5
        [Authorize(Users = "f@f.com")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolgeler bolgeler = db.Bolgelers.Find(id);
            if (bolgeler == null)
            {
                return HttpNotFound();
            }
            return View(bolgeler);
        }

        // GET: Bolgeler/Create
        [Authorize(Users = "f@f.com")]
        public ActionResult Create()
        {
            ViewBag.SehirId = new SelectList(db.Sehirlers, "Id", "Isim");
            return View();
        }

        // POST: Bolgeler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Isim,Hakkinda,SehirId")] Bolgeler bolgeler)
        {
            if (ModelState.IsValid)
            {
                db.Bolgelers.Add(bolgeler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SehirId = new SelectList(db.Sehirlers, "Id", "Isim", bolgeler.SehirId);
            return View(bolgeler);
        }

        // GET: Bolgeler/Edit/5
        [Authorize(Users = "f@f.com")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolgeler bolgeler = db.Bolgelers.Find(id);
            if (bolgeler == null)
            {
                return HttpNotFound();
            }
            ViewBag.SehirId = new SelectList(db.Sehirlers, "Id", "Isim", bolgeler.SehirId);
            return View(bolgeler);
        }

        // POST: Bolgeler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Isim,Hakkinda,SehirId")] Bolgeler bolgeler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bolgeler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SehirId = new SelectList(db.Sehirlers, "Id", "Isim", bolgeler.SehirId);
            return View(bolgeler);
        }

        // GET: Bolgeler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolgeler bolgeler = db.Bolgelers.Find(id);
            if (bolgeler == null)
            {
                return HttpNotFound();
            }
            return View(bolgeler);
        }

        // POST: Bolgeler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bolgeler bolgeler = db.Bolgelers.Find(id);
            db.Bolgelers.Remove(bolgeler);
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
