using EnglishCourse.Model.ViewModels;
using System.Collections.Generic;

namespace EnglishCourse.Logic.Interfaces
{
    public interface ITestService
    {
        IEnumerable<TestVM> GetAll();

        TestVM GetById(int id);

        void Create(TestVM model);

        void Update(TestVM model);

        void Delete(int id);
    }
}
