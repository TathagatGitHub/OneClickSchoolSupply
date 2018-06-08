using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneClickSchoolSupply.Models;

namespace OneClickSchoolSupply.Controllers
{
    public class KitItemController : Controller
    {
        private SchoolKitContext db = new SchoolKitContext();

        //
        // GET: /SchoolKit/

        public ActionResult Index()
        {
            return View(db.KitItems.ToList());
        }

        //
        // GET: /SchoolKit/Details/5

        public ActionResult Details(int id = 0)
        {
            KitItem KitItem = db.KitItems.Find(id);
            if (KitItem == null)
            {
                return HttpNotFound();
            }
            return View(KitItem);
        }

        //
        // GET: /SchoolKit/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SchoolKit/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KitItem KitItem)
        {
            if (ModelState.IsValid)
            {
                db.KitItems.Add(KitItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(KitItem);
        }

        //
        // GET: /SchoolKit/Edit/5

        public ActionResult Edit(int id = 0)
        {
            KitItem KitItem = db.KitItems.Find(id);
            if (KitItem == null)
            {
                return HttpNotFound();
            }
            return View(KitItem);
        }

        //
        // POST: /SchoolKit/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(KitItem KitItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(KitItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(KitItem);
        }

        //
        // GET: /SchoolKit/Delete/5

        public ActionResult Delete(int id = 0)
        {
            KitItem KitItem = db.KitItems.Find(id);
            if (KitItem == null)
            {
                return HttpNotFound();
            }
            return View(KitItem);
        }

        //
        // POST: /SchoolKit/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KitItem KitItem = db.KitItems.Find(id);
            db.KitItems.Remove(KitItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}