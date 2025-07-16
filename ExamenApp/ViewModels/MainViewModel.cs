using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ExamenApp.Data;
using ExamenApp.Models;
using ExamenApp.Views;
using Microsoft.EntityFrameworkCore;

namespace ExamenApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly AppDbContext _context;
        private string _searchText;
        private Product _selectedProduct;
        private Category _selectedCategory;

        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Category> Categories { get; set; }

        public string SearchText
        {
            get => _searchText;
            set { _searchText = value; OnPropertyChanged(); SearchProducts(); }
        }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set { _selectedProduct = value; OnPropertyChanged(); }
        }

        public Category SelectedCategory
        {
            get => _selectedCategory;
            set { _selectedCategory = value; OnPropertyChanged(); }
        }

        public ICommand AddProductCommand { get; }
        public ICommand EditProductCommand { get; }
        public ICommand DeleteProductCommand { get; }
        public ICommand AddCategoryCommand { get; }

        public MainViewModel()
        {
            _context = new AppDbContext();
            Products = new ObservableCollection<Product>();
            Categories = new ObservableCollection<Category>();

            AddProductCommand = new RelayCommand(AddProduct);
            EditProductCommand = new RelayCommand(EditProduct);
            DeleteProductCommand = new RelayCommand(DeleteProduct);
            AddCategoryCommand = new RelayCommand(AddCategory);

            LoadData();
        }

        private void LoadData()
        {
            var products = _context.Products.Include(p => p.Category).ToList();
            var categories = _context.Categories.ToList();

            Products.Clear();
            Categories.Clear();

            foreach (var product in products)
                Products.Add(product);

            foreach (var category in categories)
                Categories.Add(category);
        }

        private void SearchProducts()
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                LoadData();
                return;
            }

            var filteredProducts = _context.Products
                .Include(p => p.Category)
                .Where(p => p.Name.Contains(SearchText))
                .ToList();

            Products.Clear();
            foreach (var product in filteredProducts)
                Products.Add(product);
        }

        private void AddProduct()
        {
            var dialog = new ProductDialog();
            if (dialog.ShowDialog() == true)
            {
                _context.Products.Add(dialog.Product);
                _context.SaveChanges();
                LoadData();
            }
        }

        private void EditProduct()
        {
            if (SelectedProduct == null) return;

            var dialog = new ProductDialog(SelectedProduct);
            if (dialog.ShowDialog() == true)
            {
                _context.SaveChanges();
                LoadData();
            }
        }

        private void DeleteProduct()
        {
            if (SelectedProduct == null) return;

            _context.Products.Remove(SelectedProduct);
            _context.SaveChanges();
            LoadData();
        }

        private void AddCategory()
        {
            var dialog = new CategoryDialog();
            if (dialog.ShowDialog() == true)
            {
                _context.Categories.Add(dialog.Category);
                _context.SaveChanges();
                LoadData();
            }
        }
    }
}
