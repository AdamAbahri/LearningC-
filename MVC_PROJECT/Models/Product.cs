using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MVC_PROJECT.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        [Range(0, 5)]
        public double Rating { get; set; }
        public int Quantity { get; set; }
        public string? ImageUrl { get; set; } // ? means that the ImageUrl property is nullable, which means it can hold a null value. This is useful for cases where a product might not have an associated image, allowing the application to handle such scenarios gracefully without throwing exceptions.
        public int CategoryId { get; set; } // Foreign key to Category, automaticly recognized by Entity Framework as a foreign key to the Category entity because of the naming convention (CategoryId)
        public Category Category { get; set; } // Navigation property to Category, used to establish a relationship between Product and Category
    }
}
