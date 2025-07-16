using ExamenApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ExamenApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=ExamenBD;Trusted_Connection=true;TrustServerCertificate=true;");
        }
    }
}