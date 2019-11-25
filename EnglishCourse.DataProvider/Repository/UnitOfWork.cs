using EnglishCourse.DataProvider.Context;
using EnglishCourse.DataProvider.Interfaces;

namespace EnglishCourse.DataProvider.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        private AccountRepository _accountRepository;
        private ThemeRepository _themeRepository;
        private TestRepository _testRepository;
        private QuestionRepository _questionRepository;
        private AnswerRepository _answerRepository;
        private ResultRepository _resultRepository;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IAccountRepository Accounts
        {
            get
            {
                if (_accountRepository == null)
                {
                    _accountRepository = new AccountRepository(_context);
                }
                return _accountRepository;
            }
        }

        public IThemeRepository Themes
        {
            get
            {
                if (_themeRepository == null)
                {
                    _themeRepository = new ThemeRepository(_context);
                }
                return _themeRepository;
            }
        }

        public ITestRepository Tests
        {
            get
            {
                if (_testRepository == null)
                {
                    _testRepository = new TestRepository(_context);
                }
                return _testRepository;
            }
        }

        public IQuestionRepository Questions
        {
            get
            {
                if (_questionRepository == null)
                {
                    _questionRepository = new QuestionRepository(_context);
                }
                return _questionRepository;
            }
        }

        public IAnswerRepository Answers
        {
            get
            {
                if (_answerRepository == null)
                {
                    _answerRepository = new AnswerRepository(_context);
                }
                return _answerRepository;
            }
        }

        public IResultRepository Results
        {
            get
            {
                if (_resultRepository == null)
                {
                    _resultRepository = new ResultRepository(_context);
                }
                return _resultRepository;
            }
        }

        public void Save() => _context.SaveChanges();
    }
}
