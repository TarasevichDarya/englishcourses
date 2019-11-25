using System.ComponentModel.DataAnnotations;

namespace EnglishCourse.Model.ViewModels
{
    public class ThemeVM
    {
        public int ThemeId { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "The length of the string must be from 3 to 40 characters")]
        public string Name { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 3, ErrorMessage = "The length of the string must be from 3 to 2000 characters.")]
        public string Description { get; set; }
    }
}
