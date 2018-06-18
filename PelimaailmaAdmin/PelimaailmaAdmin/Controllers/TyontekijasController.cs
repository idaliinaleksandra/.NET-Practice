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
    public class TyontekijasController : Controller
    {
        private pelimaailmaEntities db = new pelimaailmaEntities();

        // GET: Tyontekijas
        public ActionResult Index()
        {
            return View(db.Tyontekija.ToList());
        }

        // GET: Tyontekijas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tyontekija tyontekija = db.Tyontekija.Find(id);
            if (tyontekija == null)
            {
                return HttpNotFound();
            }
            return View(tyontekija);
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
