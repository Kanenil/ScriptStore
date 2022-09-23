using DataLayer.DataContext;

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
