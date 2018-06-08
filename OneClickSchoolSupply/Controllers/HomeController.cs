using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneClickSchoolSupply.Models;
namespace OneClickSchoolSupply.Controllers
{
    public class HomeController : Controller
    {
        private SchoolKitContext db = new SchoolKitContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome Teachers, PTO, PTA, & Parents!!";

            return View();
        }
        public ActionResult RemoteData(string query)
        {
            List<string> listData = null;
            //checking the query parameter sent from view. If it is null we will return null else we will return list based on query.
            if (!string.IsNullOrEmpty(query))
            {
                //Created an array of players. We can fetch this from database as well. OR USE the DB query to pull the data
                string[] arrayData = new string[] { "Fabregas", "Messi", "Ronaldo", "Ronaldinho", "Goetze", "Cazorla", "Henry", "Luiz", "Reus", "Neur", "Podolski" };

                //Using Linq to query the result from an array matching letter entered in textbox.
                listData = arrayData.Where(q => q.ToLower().Contains(query.ToLower())).ToList();
            }

            //Returning the matched list as json data.
            return Json(new { Data = listData });
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult HowItWorks()
        {
            ViewBag.Message = "How It Works!";

            return View();
        }
        public ActionResult HowToBuy()
        {
            ViewBag.Message = "How to Buy!";

            return View();
        }
    }
}
