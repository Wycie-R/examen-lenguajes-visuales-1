using System;
using System.Windows;
using ExamenApp.Models;

namespace ExamenApp.Views
{
    public partial class CategoryDialog : Window
    {
        public Category Category { get; set; }

        public CategoryDialog(Category category = null)
        {
            InitializeComponent();
            Category = category ?? new Category();

            if (!string.IsNullOrEmpty(Category.Name))
            {
                NameTextBox.Text = Category.Name;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("El nombre es requerido");
                return;
            }

            Category.Name = NameTextBox.Text;
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