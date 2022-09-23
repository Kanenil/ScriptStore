using DataLayer.Models;
using System.Data.Entity;

namespace DataLayer.DataContext
{
    public class StoreContext : DbContext
    {
        public StoreContext(string connectionString) : base(connectionString) { }
        public DbSet<Product> Products { get; set; }
        private void FixEfProviderServicesProblem()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
