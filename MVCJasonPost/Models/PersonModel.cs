using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data.Entity;
using System.Data;

namespace MVCJasonPost.Models
{
    public class PersonModel
    {
        [DisplayName("First")]
        public string First { get; set; }
        [DisplayName("Last")]
        public string Last { get; set; }
        [DisplayName("Favorite Bands")]
        public List<string> FavoriteBands { get; set; }
    }

    public class DB : DbContext
    {
        public DbSet<PersonModel> Persons { get; set; }
    }
}