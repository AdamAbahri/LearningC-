using System.Diagnostics.CodeAnalysis;

namespace MVC_PROJECT.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; } // Navigation property to Product, used to establish a relationship between Category and Product it means (a category can have multiple products)
    }
}
