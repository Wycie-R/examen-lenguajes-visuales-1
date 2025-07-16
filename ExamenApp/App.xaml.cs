using System.Windows;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore; // ← Agrega esta línea
using ExamenApp.Views;
using ExamenApp.Data;

namespace ExamenApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            try
            {
                // Crear base de datos si no existe
                using (var context = new AppDbContext())
                {
                    context.Database.EnsureCreated();

                    // Agregar datos iniciales si es necesario
                    if (!context.Categories.Any())
                    {
                        context.Categories.Add(new Models.Category { Name = "Electrónicos" });
                        context.Categories.Add(new Models.Category { Name = "Ropa" });
                        context.Categories.Add(new Models.Category { Name = "Hogar" });
                        context.SaveChanges();
                    }
                }

                // Mostrar ventana de login
                var loginWindow = new LoginWindow();
                loginWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Shutdown();
            }
        }
    }
}