using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data.Entity;
using System.Data;
using System.ComponentModel.DataAnnotations;

using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;

namespace MVCJasonPost.Models
{
    public class PersonModel
    {
        [Key]
        public int id { get; set; }

        [DisplayName("First")]
        public string First { get; set; }

        [DisplayName("Last")]
        public string Last { get; set; }

        [DisplayName("Favorite Bands")]
        public string FavoriteBands { get; set; }
    }

    public class DB : DbContext
    {
        public DbSet<PersonModel> Persons { get; set; }
    }

    public class JsonHelper
    {

        public static string JsonSerializer<T>(T t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }

        public static T JsonDeserialize<T>(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }
    }
}