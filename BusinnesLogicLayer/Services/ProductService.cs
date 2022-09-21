using BusinnesLogicLayer.Interfaces;
using BusinnesLogicLayer.Models;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLogicLayer.Services
{
    public class ProductService : IServiceMethods<ProductDTO>
    {
        private readonly ProductRepository _productRepository;
        public ProductService(string connectionString)
        {
            _productRepository = new ProductRepository(connectionString);
        }
        public void AddItem(object item)
        {
            if (item is ProductDTO)
                AddProduct((ProductDTO)item);
        }

        private void AddProduct(ProductDTO item)
        {
            var product = new DataLayer.Models.Product
            {
                ProductName = item.ProductName,
                Price = item.Price,
                Count = item.Count,
                SupplierName = item.SupplierName
            };

            _productRepository.Create(product);
        }

        public void DeleteDTO(ProductDTO item)
        {
            _productRepository.Delete(new DataLayer.Models.Product() 
            {
                ProductName = item.ProductName,
                Price = item.Price,
                Count = item.Count,
                SupplierName = item.SupplierName
            });
        }

        public ProductDTO FindDTO(string item)
        {
            var product = _productRepository.Find(item);
            return new ProductDTO()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                Count = product.Count,
                SupplierName = product.SupplierName
            };
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var products = new List<ProductDTO>();
            foreach (var item in _productRepository.GetAll())
            {
                products.Add(new ProductDTO
                {
                    Id = item.Id,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Count = item.Count,
                    SupplierName = item.SupplierName
                });
            }
            return products;
        }

        public int GetIdDTO(ProductDTO item)
        {
            return _productRepository.GetId(new DataLayer.Models.Product() 
            {
                Id = item.Id,
                ProductName = item.ProductName,
                Price = item.Price,
                Count = item.Count,
                SupplierName = item.SupplierName
            });
        }

        public void UpdateDTO(ProductDTO item)
        {
            _productRepository.Update(new DataLayer.Models.Product() 
            {
                Id = item.Id,
                ProductName = item.ProductName,
                Price = item.Price,
                Count = item.Count,
                SupplierName = item.SupplierName
            });
        }
    }
}
