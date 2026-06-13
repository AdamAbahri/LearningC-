using MVC_PROJECT.ViewModels.ImageViewModels;
using System.ComponentModel.DataAnnotations;

namespace MVC_PROJECT.ViewModels.ProductsViewModels
{
    public class EditProductsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        [Range(0, 5)]
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public List<IFormFile>? Images { get; set; }
        public List<ImagesViewModel> ExistingImages { get; set; } = new(); 

    }
}
