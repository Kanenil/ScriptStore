using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(40)]
        public string ProductName { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public string SupplierName { get; set; }
    }
}
