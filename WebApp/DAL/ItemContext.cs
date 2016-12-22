using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp;

namespace WebApp
{
    public class ItemContext : DbContext
    {
        static ItemContext()
        {
            Database.SetInitializer<ItemContext>(new ItemsInitializer());
        }
        public ItemContext() : base("WebApi")
        { }
        public DbSet<Item> Items { get; set; }
    }
}