using System.ComponentModel.DataAnnotations;

namespace EnglishCourse.Model.ViewModels
{
    public class TestVM
    {
        public int TestId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The length of the string must be from 3 to 50 characters")]
        public string Name { get; set; }

        [Required]
        public int ThemeId { get; set; }

        public string Theme { get; set; }
    }
}
