using SecondWebAPI.Authentication;
using SecondWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SecondWebAPI.Context
{
    public class UserContext : DbContext
    {
        static UserContext()
        {
            Database.SetInitializer<UserContext>(new UsersInitializer());
        }
        public UserContext() : base("UserDb")
        { }
        public DbSet<User> Users { get; set; }
    }
}