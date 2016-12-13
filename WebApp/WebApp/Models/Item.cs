using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Tittle { get; set; }
        public string Task { get; set; }
        public DateTime CreateDate { get; set; }
    }
}