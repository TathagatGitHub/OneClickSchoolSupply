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
    public class SchoolKitController : Controller
    {
        private SchoolKitContext db = new SchoolKitContext();

        //
        // GET: /SchoolKit/

        public ActionResult Index()
        {
            return View(db.SchoolKits.ToList());
        }
        public ActionResult TabView()
        {
            return View();
        }
        public ActionResult Search(string searchString)
        {
            var kits = from m in db.SchoolKits
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                kits = kits.Where(s => s.Name.Contains(searchString));
            }

            return View("Index",kits);
        }

        // GET: /SchoolKitListView/

        public ActionResult SchoolKitList(string SchoolName = "")
        {
            IQueryable<SchoolKit> query = db.SchoolKits;
            //List<SchoolKit> schoolkit = db.SchoolKits.ToList(SchoolName);

            query = query.Where(p => p.SchoolName == SchoolName);

            if (query == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView("_IndexPartiaView", query);
            }
            else
                return View("Index",query);

                       
        }

        //
        // GET: /SchoolKit/Details/5

        public ActionResult Details(int id = 0)
        {
            SchoolKit schoolkit = db.SchoolKits.Find(id);
            if (schoolkit == null)
            {
                return HttpNotFound();
            }
            return View(schoolkit);
        }

        //
        // GET: /SchoolKit/Create - Normal Window create

        public ActionResult Create()
        {
            return View();
        }
       
        // Model Window Creare Action, 
        [HttpGet]
        public ActionResult CreateSchoolKitUsingParticalView(int? id)
        {
            return PartialView("_CreateSchoolKitPartialView");

            if (Request.IsAjaxRequest()) // checking if JavaScript is enabled
            {
                if (id != null)
                {
                    ViewBag.IsUpdate = true;
                    SchoolKit schoolKit = db.SchoolKits.Where(m => m.KitId == id).FirstOrDefault();
                    return PartialView("_CreateSchoolKit-PartialView", schoolKit);
                }
                ViewBag.IsUpdate = false;

                return PartialView("_CreateSchoolKit-PartialView");
            }
            else
            {
                if (id != null)
                {
                    ViewBag.IsUpdate = true;
                    SchoolKit schoolKit = db.SchoolKits.Where(m => m.KitId == id).FirstOrDefault();
                    return PartialView("Create", schoolKit);
                }
                ViewBag.IsUpdate = false;
                return View("Create");
            }
        }
        //
        // POST: /SchoolKit/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SchoolKit schoolkit)
        {
            if (ModelState.IsValid)
            {
                db.SchoolKits.Add(schoolkit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(schoolkit);
        }

        //
        // GET: /SchoolKit/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SchoolKit schoolkit = db.SchoolKits.Find(id);
            if (schoolkit == null)
            {
                return HttpNotFound();
            }
            return View(schoolkit);
        }
            
        public ActionResult EditDialog(int id = 0)
        {
            SchoolKit schoolkit = db.SchoolKits.Find(id);
            if (schoolkit == null)
            {
                return HttpNotFound();
            }
            return PartialView("_schoolkitEditPartialView", schoolkit);
        }

        

        //
        // POST: /SchoolKit/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SchoolKit schoolkit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schoolkit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(schoolkit);
        }

        //
        // GET: /SchoolKit/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SchoolKit schoolkit = db.SchoolKits.Find(id);
            if (schoolkit == null)
            {
                return HttpNotFound();
            }
            return View(schoolkit);
        }

        //
        // POST: /SchoolKit/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SchoolKit schoolkit = db.SchoolKits.Find(id);
            db.SchoolKits.Remove(schoolkit);
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