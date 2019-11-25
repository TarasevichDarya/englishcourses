using System.ComponentModel.DataAnnotations;

namespace EnglishCourse.Model.ViewModels
{
    public class LoginVM
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email not specified")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Message { get; set; }
    }
}
