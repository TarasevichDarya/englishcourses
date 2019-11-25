using System.ComponentModel.DataAnnotations;

namespace EnglishCourse.DataProvider.Entities
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }

        [Required]
        [StringLength(150)]
        public string Text { get; set; }

        [Required]
        public bool IsRight { get; set; }

        [Required]
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

    }
}
