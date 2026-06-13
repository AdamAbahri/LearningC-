using System.ComponentModel.DataAnnotations;

namespace MVC_PROJECT.ViewModels.CategoriesViewModels
{
    public class CreateCategoriesViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

    }
}
