using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PelimaailmaAdmin.Models;

namespace PelimaailmaAdmin.Controllers
{
    public class PelitController : Controller
    {
        private pelimaailmaEntities db = new pelimaailmaEntities();

        // GET: Pelit
        public ActionResult Index()
        {
            return View(db.Pelit.ToList());
        }

        // GET: Pelit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelit pelit = db.Pelit.Find(id);
            if (pelit == null)
            {
                return HttpNotFound();
            }
            return View(pelit);
        }

        // GET: Pelit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pelit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PeliId,Nimi,Vuosi,Alusta,Hinta")] Pelit pelit)
        {
            if (ModelState.IsValid)
            {
                db.Pelit.Add(pelit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pelit);
        }

        // GET: Pelit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelit pelit = db.Pelit.Find(id);
            if (pelit == null)
            {
                return HttpNotFound();
            }
            return View(pelit);
        }

        // POST: Pelit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PeliId,Nimi,Vuosi,Alusta,Hinta")] Pelit pelit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pelit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pelit);
        }

        // GET: Pelit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelit pelit = db.Pelit.Find(id);
            if (pelit == null)
            {
                return HttpNotFound();
            }
            return View(pelit);
        }

        // POST: Pelit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pelit pelit = db.Pelit.Find(id);
            db.Pelit.Remove(pelit);
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
