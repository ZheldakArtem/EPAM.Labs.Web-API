using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp;
using WebApp.Models;

namespace WebApp
{
    public class ItemContext : DbContext
    {
        public ItemContext() : base("WebApi")
        { }
        public DbSet<Item> Items { get; set; }
    }
}