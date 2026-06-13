using MVC_PROJECT.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC_PROJECT.ViewModels.ProductsViewModels
{
    public class ProductsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        [Range(0, 5)]
        public double Rating { get; set; }
        public int Quantity { get; set; }
        public string CategoryName { get; set; }
        public List<string> Images { get; set; } = new();

    }

}
