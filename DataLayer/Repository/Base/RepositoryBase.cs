using DataLayer.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Base
{
    public abstract class RepositoryBase
    {
        protected StoreContext _storeContext;
        public RepositoryBase(string connectionString)
        {
            _storeContext = new StoreContext(connectionString);
        }
    }
}
