using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<T>: IDisposable
    {
        IEnumerable<T> Get();

        T Get(int id);

        bool Add(T item);

        bool UpDate(int id, T item);

        bool Delete(int id);
    }
}
