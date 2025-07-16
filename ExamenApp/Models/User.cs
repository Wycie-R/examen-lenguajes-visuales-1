using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamenApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Username { get; set; }
        [Required, StringLength(100)]
        public string Password { get; set; }
        [Required, StringLength(100)]
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class Product
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new();
    }
}