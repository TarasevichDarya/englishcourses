namespace EnglishCourse.DataProvider.Interfaces
{
    public interface IUnitOfWork
    {
        IAccountRepository Accounts { get; }
        IThemeRepository Themes { get; }
        ITestRepository Tests { get; }
        IQuestionRepository Questions { get; }
        IAnswerRepository Answers { get; }
        IResultRepository Results { get; }

        void Save();
    }
}
