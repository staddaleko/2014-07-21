using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVCJasonPost.Models;
using MVCJasonPost.API;

namespace MVCJasonPost.Controllers
{
    public class PersonController : Controller
    {
        public MyAPIController api = new MyAPIController();

        public ActionResult Index()
        {
            var list = api.Get();
            return View("Index", list);
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(PersonModel obj)
        {
            try
            {
                List<string> person = new List<string>();
                person.Add(obj.First);
                person.Add(obj.Last);
                person.Add(obj.FavoriteBands);
                api.Post(person);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View("Create");
            }
        }

        public ActionResult Edit(int id)
        {
            PersonModel person = api.Get(id);
            return View("Edit", person);
        }

        [HttpPost]
        public ActionResult Edit(int id, PersonModel obj)
        {
            try
            {
                api.Put(id, obj);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View("Edit");
            }
        }

        public ActionResult Delete(int id)
        {
            PersonModel person = api.Get(id);
            return View("Delete", person);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                api.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
        }


        //[HttpGet]
        //public ActionResult Index()
        //{
        //    return View(new PersonModel());
        //}

        public ActionResult List()
        {
            var db = new DB();
            return View("List", db.Persons.ToList());
        }

        [HttpPost]
        public JsonResult BadSave(string first, string last, List<string> favoriteBands)
        {
            #region Gdy usuniemy tą część kodu, sam skrypt się wykonuje...
            /*var db = new DB();
            PersonModel P = new PersonModel();
            P.First = first;
            P.Last = last;
            foreach (string fb in favoriteBands)
            {
                P.FavoriteBands.Add(fb);
            }
            db.Persons.Add(P);
            db.SaveChanges(); */
            #endregion
            return Json(new { result = "saved the bad way" });
        }

        [HttpPost]
        public JsonResult GoodSave(PersonModel model)
        {
            #region bez tego kodu również skrypt działa...
            /*var db = new DB();
            db.Persons.Add(model);
            db.SaveChanges();*/
            #endregion
            return Json(new { result = "saved the good way" });

        }
    }
}