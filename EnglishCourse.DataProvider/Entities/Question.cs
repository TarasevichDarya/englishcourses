using System.ComponentModel.DataAnnotations;

namespace EnglishCourse.DataProvider.Entities
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Required]
        [StringLength(150)]
        public string Text { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        public int TestId { get; set; }

        public virtual Test Test { get; set; }
    }
}
