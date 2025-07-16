using System;
using System.Linq;
using System.Windows;
using ExamenApp.Data;
using ExamenApp.Models;

namespace ExamenApp.Views
{
    public partial class ProductDialog : Window
    {
        public Product Product { get; set; }
        private readonly AppDbContext _context;

        public ProductDialog(Product product = null)
        {
            InitializeComponent();
            _context = new AppDbContext();
            Product = product ?? new Product();

            LoadCategories();
            LoadProductData();
        }

        private void LoadCategories()
        {
            CategoryComboBox.ItemsSource = _context.Categories.ToList();
        }

        private void LoadProductData()
        {
            NameTextBox.Text = Product.Name;
            PriceTextBox.Text = Product.Price.ToString();
            if (Product.CategoryId > 0)
            {
                CategoryComboBox.SelectedValue = Product.CategoryId;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("El nombre es requerido");
                return;
            }

            if (!decimal.TryParse(PriceTextBox.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("El precio debe ser un numero valido mayor que 0");
                return;
            }

            if (CategoryComboBox.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una categoria");
                return;
            }

            Product.Name = NameTextBox.Text;
            Product.Price = price;
            Product.CategoryId = (int)CategoryComboBox.SelectedValue;

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}