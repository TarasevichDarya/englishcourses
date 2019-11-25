using System.ComponentModel.DataAnnotations;

namespace EnglishCourse.Model.ViewModels
{
    public class QuestionVM
    {
        public int QuestionId { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "The length of the string must be from 3 to 150 characters")]
        public string Text { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        public int TestId { get; set; }

        public string Test { get; set; }
    }
}
