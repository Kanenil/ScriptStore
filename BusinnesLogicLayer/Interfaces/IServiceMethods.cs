using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLogicLayer.Interfaces
{
    interface IServiceMethods<T>
    {
        IEnumerable<T> GetAll();
        void AddItem(object item);
        T FindDTO(string id);
        void UpdateDTO(T item);
        void DeleteDTO(T id);
        int GetIdDTO(T item);
    }
}
