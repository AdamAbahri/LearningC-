using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        [MinLength(3,ErrorMessage ="Minimum Length is 3")]
        [MaxLength(25,ErrorMessage ="Max Length is 25")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Email is Required")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")] //Validates that the value is a valid email format
        [DataType(DataType.EmailAddress)] //Specifies that the data type of the property is an email address, which can be used for rendering and validation purposes
        public string Email { get; set; }
        [Required(ErrorMessage ="Age is Required")]
        [Range(18, 100, ErrorMessage ="Age must be between 18 and 100")]
        public int Age { get; set; }
        [Required(ErrorMessage ="Score is Required")]
        public decimal Score { get; set; }
    }
}
