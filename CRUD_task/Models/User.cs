using System.ComponentModel.DataAnnotations;

namespace CRUD_task.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long")]
        [MaxLength(25, ErrorMessage = "Name cannot exceed 25 characters")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Age is required"), Range(18, 60, ErrorMessage = "Age must be between 18 and 60")]
        public int Age { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
    }
}
