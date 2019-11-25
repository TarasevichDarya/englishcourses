using System.ComponentModel.DataAnnotations;

namespace EnglishCourse.DataProvider.Entities
{
    public class Test
    {
        [Key]
        public int TestId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int ThemeId { get; set; }

        public virtual Theme Theme { get; set; }

    }
}
