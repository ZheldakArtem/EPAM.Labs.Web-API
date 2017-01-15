using SecondWebAPI.Context;
using SecondWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondWebAPI.Authentication
{
    public class UserRepository :IRepository<User>
    {
        private UserContext db = new UserContext();             

        public User FindByPredicate(Func<User, bool> predicate)
        {
            return db.Users.FirstOrDefault(predicate);
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}