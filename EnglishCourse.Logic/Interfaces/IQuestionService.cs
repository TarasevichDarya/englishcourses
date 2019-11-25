using EnglishCourse.Model.ViewModels;
using System.Collections.Generic;

namespace EnglishCourse.Logic.Interfaces
{
    public interface IQuestionService
    {
        IEnumerable<QuestionVM> GetAll();

        QuestionVM GetById(int id);

        void Create(QuestionVM model);

        void Update(QuestionVM model);

        void Delete(int id);
    }
}
