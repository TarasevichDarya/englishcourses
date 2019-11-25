using EnglishCourse.DataProvider.Entities;
using System.Collections.Generic;

namespace EnglishCourse.DataProvider.Interfaces
{
    public interface IResultRepository
    {
        IEnumerable<Result> GetAll();

        void Create(Result entity);
    }
}
