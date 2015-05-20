using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Amigos.DataAccessLayer;
using Amigos.Models;

namespace Amigos.Controllers
{
    public class GCMModelsController : Controller
    {
        private GCMDBContext db = new GCMDBContext();

        // GET: GCMModels
        public ActionResult Index()
        {
            return View(db.GCMs.ToList());
        }

        // GET: GCMModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GCMModel gCMModel = db.GCMs.Find(id);
            if (gCMModel == null)
            {
                return HttpNotFound();
            }
            return View(gCMModel);
        }

        // GET: GCMModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GCMModels/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,regID")] GCMModel gCMModel)
        {
            if (ModelState.IsValid)
            {
                db.GCMs.Add(gCMModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gCMModel);
        }

        // GET: GCMModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GCMModel gCMModel = db.GCMs.Find(id);
            if (gCMModel == null)
            {
                return HttpNotFound();
            }
            return View(gCMModel);
        }

        // POST: GCMModels/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,regID")] GCMModel gCMModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gCMModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gCMModel);
        }

        // GET: GCMModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GCMModel gCMModel = db.GCMs.Find(id);
            if (gCMModel == null)
            {
                return HttpNotFound();
            }
            return View(gCMModel);
        }

        // POST: GCMModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GCMModel gCMModel = db.GCMs.Find(id);
            db.GCMs.Remove(gCMModel);
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
