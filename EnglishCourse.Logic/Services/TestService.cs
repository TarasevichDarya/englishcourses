using System.Collections.Generic;
using EnglishCourse.DataProvider.Entities;
using EnglishCourse.DataProvider.Interfaces;
using EnglishCourse.Logic.Interfaces;
using EnglishCourse.Model.ViewModels;
using System.Linq;

namespace EnglishCourse.Logic.Services
{
    public class TestService : ITestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(TestVM model)
        {
            _unitOfWork.Tests.Create(new Test { Name = model.Name, ThemeId = model.ThemeId });
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            Test test = _unitOfWork.Tests.GetById(id);

            if(test != null)
            {
                _unitOfWork.Tests.Delete(test);
                _unitOfWork.Save();
            }
        }

        public IEnumerable<TestVM> GetAll()
        {
            return _unitOfWork.Tests.GetAll()
                .Select(x => new TestVM { TestId = x.TestId, Name = x.Name, ThemeId = x.ThemeId, Theme = x.Theme.Name });
        }

        public TestVM GetById(int id)
        {
            Test test = _unitOfWork.Tests.GetById(id);

            return new TestVM { TestId = test.TestId, Name = test.Name, ThemeId = test.ThemeId, Theme = test.Theme.Name };
        }

        public void Update(TestVM model)
        {
            _unitOfWork.Tests.Update(new Test { TestId = model.TestId, Name = model.Name, ThemeId = model.ThemeId });

            _unitOfWork.Save();
        }
    }
}
