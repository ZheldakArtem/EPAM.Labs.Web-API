using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondWebAPI.Authentication
{
    public interface IRepository<T> : IDisposable
    {
        T FindByPredicate(Func<T, bool> predicate);
    }
}
