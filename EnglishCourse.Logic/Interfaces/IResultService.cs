using EnglishCourse.Model.ViewModels;
using System.Collections.Generic;

namespace EnglishCourse.Logic.Interfaces
{
    public interface IResultService
    {
        IEnumerable<ResultVM> GetAll();

        void Create(ResultVM model);
    }
}
