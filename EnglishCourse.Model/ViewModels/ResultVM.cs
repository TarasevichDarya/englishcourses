using System;

namespace EnglishCourse.Model.ViewModels
{
    public class ResultVM
    {
        public int ResultId { get; set; }

        public DateTime TimeStart { get; set; }

        public int TotalScore { get; set; }

        public int TestId { get; set; }

        public string Test { get; set; }

        public int AccountId { get; set; }
    }
}
