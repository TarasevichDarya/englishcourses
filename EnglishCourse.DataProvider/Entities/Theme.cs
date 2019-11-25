using System.ComponentModel.DataAnnotations;

namespace EnglishCourse.DataProvider.Entities
{
    public class Theme
    {
        [Key]
        public int ThemeId { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }
    }
}
