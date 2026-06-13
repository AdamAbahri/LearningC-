using System.ComponentModel.DataAnnotations;

namespace MVC_PROJECT.ViewModels.CategoriesViewModels
{
    public class EditCategoriesViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
    }
}
