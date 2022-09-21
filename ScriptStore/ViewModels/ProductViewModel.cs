using BusinnesLogicLayer.Models;
using BusinnesLogicLayer.Services;
using ScriptStore.Commands;
using ScriptStore.View;
using ScriptStore.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ScriptStore.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private readonly ProductService _productService;
        private ProductDTO _selected;
        public ProductDTO Selected { get => _selected; set { _selected = value; OnPropertyChanged(); } }
        private List<ProductDTO> _products;
        public List<ProductDTO> Products { get => _products; set { _products = value; OnPropertyChanged(); } }
        public ProductViewModel()
        {
            _productService = new ProductService(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
            Selected = null;
            Products = _productService.GetAll().ToList();


            DeleteProduct = new RelayCommand((a) => { _productService.DeleteDTO(Selected); Products = _productService.GetAll().ToList(); }, (a)=>Selected!=null);
            GetAll = new RelayCommand((a) => Products = _productService.GetAll().ToList());
            AddProduct = new RelayCommand((a) => {
                var window = new ProductWindow();
                ProductName = String.Empty;
                Count = 0;
                Price = 0.0m;
                SupplierName = String.Empty;
                window.DataContext = this;
                window.actionButton.Command = new RelayCommand((b)=> AddProductMethod(), (b)=>!String.IsNullOrEmpty(ProductName) && !String.IsNullOrEmpty(SupplierName) && Count > 0 && Price > 0);
                window.actionButton.Content = "Добавити";
                window.Title = "Добавити Продукт";
                window.ShowDialog();
                Products = _productService.GetAll().ToList();
            });
            UpdateProduct = new RelayCommand((a) => {
                var window = new ProductWindow();
                ProductName = Selected.ProductName;
                Count = Selected.Count;
                Price = Selected.Price;
                SupplierName = Selected.SupplierName;
                window.DataContext = this;
                window.actionButton.Command = new RelayCommand((b) => UpdateProductMethod(), (b) => !String.IsNullOrEmpty(ProductName) && !String.IsNullOrEmpty(SupplierName) && Count > 0 && Price > 0);
                window.actionButton.Content = "Редагувати";
                window.Title = "Редагувати Продукт";
                window.ShowDialog();
                Products = _productService.GetAll().ToList();
            },(obj)=>Selected!=null);
        }
        public RelayCommand AddProduct { get; }
        public RelayCommand UpdateProduct { get; }
        public RelayCommand DeleteProduct { get; }
        public RelayCommand GetAll { get; }

        private void UpdateProductMethod()
        {
            _productService.UpdateDTO(new ProductDTO() {Id = Selected.Id, ProductName = ProductName, Price = Price, Count = Count, SupplierName = SupplierName });
            MessageBox.Show("Продукт успішно відредаговано", "Відредаговано");
        }

        private async void AddProductMethod()
        {
            await _productService.AddItemAsync(new ProductDTO() { ProductName = ProductName,Price = Price,Count = Count,SupplierName =SupplierName });
            MessageBox.Show("Продукт успішно додано", "Додано");
        }

        private string _productName;
        public string ProductName { get => _productName; set { _productName = value; OnPropertyChanged(); } }
        private int _count;
        public int Count { get => _count; set { _count = value; OnPropertyChanged(); } }
        private decimal _price;
        public decimal Price { get => _price; set { _price = value; OnPropertyChanged(); } }
        private string _supplierName;
        public string SupplierName { get => _supplierName; set { _supplierName = value; OnPropertyChanged(); } }
    }
}
