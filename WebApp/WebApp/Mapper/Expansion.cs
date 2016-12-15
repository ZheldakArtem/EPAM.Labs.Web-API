using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Mapp
{
    public static class Expansion
    {
        public static Item ToItem(this ClientItem vItem)
        {
            return new Item
            {
                Id = vItem.Id,
                Author = vItem.Author,
                CreateDate = vItem.CreateDate,
                Task = vItem.Task,
                Tittle = vItem.Tittle
            };
        }

        public static ClientItem ToClientItemm(this Item cItem)
        {
            return new ClientItem
            {
                Id = cItem.Id,
                Author = cItem.Author,
                CreateDate = cItem.CreateDate,
                Task = cItem.Task,
                Tittle = cItem.Tittle
            };
        }
    }
}