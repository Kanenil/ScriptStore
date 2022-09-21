using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
