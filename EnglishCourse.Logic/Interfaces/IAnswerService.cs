using EnglishCourse.Model.ViewModels;
using System.Collections.Generic;

namespace EnglishCourse.Logic.Interfaces
{
    public interface IAnswerService
    {
        IEnumerable<AnswerVM> GetAll();

        AnswerVM GetById(int id);

        void Create(AnswerVM model);
        
        void Update(AnswerVM model);

        void Delete(int id);
    }
}
