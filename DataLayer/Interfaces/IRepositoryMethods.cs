using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IRepositoryMethods<T> where T : class
    {
        T Find(string value);
        IEnumerable<T> GetAll();
        void Create(T item);
        void Update(T item);
        void Delete(T id);
        int GetId(T item);
    }
}
