using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp;
using WebApp.Models;

namespace DAL
{
    public class ItemReopsitory : IRepository<Item>
    {
        private ItemContext db = new ItemContext();

        public bool Add(Item item)
        {
            db.Items.Add(item);
            return db.SaveChanges() > 0 ? true : false;
        }

        public bool Delete(int id)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return false;
            }

            db.Items.Remove(item);
            return db.SaveChanges() > 0 ? true : false;
        }      

        public IEnumerable<Item> Get()
        {
            return db.Items;
        }

        public Item Get(int id)
        {
            return db.Items.Find(id);
        }

        public bool UpDate(int id, Item item)
        {

            db.Entry(item).State = EntityState.Modified;

            return db.SaveChanges() > 0 ? true : false;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
