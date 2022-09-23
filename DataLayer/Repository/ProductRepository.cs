using DataLayer.Interfaces;
using DataLayer.Models;
using DataLayer.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repository
{
    public class ProductRepository : RepositoryBase, IRepositoryMethods<Product>
    {
        public ProductRepository(string connectionString) : base(connectionString) {}

        public void Create(Product item)
        {
            if (item != null)
            {
                _storeContext.Products.Add(item);
                _storeContext.SaveChanges();
            }
        }

        public void Delete(Product item)
        {
            _storeContext.Products.Remove(_storeContext.Products.First(e => e.ProductName == item.ProductName && e.Price == item.Price && e.Count == item.Count && e.SupplierName == item.SupplierName));
            _storeContext.SaveChanges();
        }

        public Product Find(string item)
        {
            var employee = _storeContext.Products.Find(item);
            if (employee != null)
                return employee;
            throw new InvalidOperationException();
        }

        public IEnumerable<Product> GetAll()
        {
            return _storeContext.Products;
        }

        public int GetId(Product item)
        {
            var tempItem = _storeContext.Products.Where(e => e.ProductName == item.ProductName && e.Count == item.Count && e.Price == item.Price && e.SupplierName == item.SupplierName).First();
            return tempItem.Id;
        }

        public void Update(Product item)
        {
            if (item != null)
            {
                var newItem = _storeContext.Products.Where(x => x.Id == item.Id).First();
                newItem.ProductName = item.ProductName;
                newItem.Count = item.Count;
                newItem.Price = item.Price;
                newItem.SupplierName = item.SupplierName;
                _storeContext.SaveChanges();
            }
        }
    }
}
