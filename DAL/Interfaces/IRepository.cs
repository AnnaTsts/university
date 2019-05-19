using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T, Tkey> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Tkey id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Insert(T obj);
    }
}
