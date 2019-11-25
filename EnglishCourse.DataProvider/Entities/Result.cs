using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCourse.DataProvider.Entities
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }

        public DateTime TimeStart { get; set; }

        public DateTime TimeFinish { get; set; }

        public int TotalScore { get; set; }

        public int TestId { get; set; }

        public virtual Test Test { get; set; }

        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}
