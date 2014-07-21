using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVCJasonPost.Models;

namespace MVCJasonPost.Controllers
{
    public class PersonController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new PersonModel());
        }

        public ActionResult List()
        {
            var db = new DB();
            return View("List", db.Persons.ToList());
        }

        [HttpPost]
        public JsonResult BadSave(string first, string last, List<string> favoriteBands)
        {
            #region Gdy usuniemy tą część kodu, sam skrypt się wykonuje...
            var db = new DB();
            PersonModel P = new PersonModel();
            P.First = first;
            P.Last = last;
            foreach (string fb in favoriteBands)
            {
                P.FavoriteBands.Add(fb);
            }
            db.Persons.Add(P);
            db.SaveChanges(); 
            #endregion
            return Json(new { result = "saved the bad way" });
        }

        [HttpPost]
        public JsonResult GoodSave(PersonModel model)
        {
            #region bez tego kodu również skrypt działa...
            var db = new DB();
            db.Persons.Add(model);
            db.SaveChanges(); 
            #endregion
            return Json(new { result = "saved the good way" });

        }
    }
}