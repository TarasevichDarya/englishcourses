using System.ComponentModel.DataAnnotations;

namespace EnglishCourse.Model.ViewModels
{
    public class AnswerVM
    {
        public int AnswerId { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "The length of the string must be from 3 to 150 characters")]
        public string Text { get; set; }

        [Required]
        public bool IsRight { get; set; }

        [Required]
        public int QuestionId { get; set; }

        public string Question { get; set; }
    }
}
