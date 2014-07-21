using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCJasonPost.Models;

namespace MVCJasonPost.API
{
    public class MyAPIController : ApiController
    {
        public DB db = new DB();
        public IEnumerable<PersonModel> Get()
        {
            return db.Persons.ToList();
        }

        public PersonModel Get(int id)
        {
            return db.Persons.Find(id);
        }

        public void Post(List<string> val)
        {
            try
            {
                PersonModel obj = new PersonModel();
                obj.First = val[0];
                obj.Last = val[1];
                obj.FavoriteBands = val[2];
                db.Persons.Add(obj);
                db.SaveChanges();
            }
            catch (Exception) { }
        }

        public void Put(int id, PersonModel obj)
        {
            try
            {
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception) { }
        }

        public void Delete(int id)
        {
            PersonModel obj = db.Persons.Find(id);
            db.Persons.Remove(obj);
            db.SaveChanges();
        }
    }
}
