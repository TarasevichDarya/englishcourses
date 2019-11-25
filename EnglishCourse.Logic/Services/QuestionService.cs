using System.Collections.Generic;
using System.Linq;
using EnglishCourse.DataProvider.Entities;
using EnglishCourse.DataProvider.Interfaces;
using EnglishCourse.Logic.Interfaces;
using EnglishCourse.Model.ViewModels;

namespace EnglishCourse.Logic.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(QuestionVM model)
        {
            _unitOfWork.Questions.Create(new Question { Text = model.Text, Score = model.Score, TestId = model.TestId });
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            Question question = _unitOfWork.Questions.GetById(id);

            if(question != null)
            {
                _unitOfWork.Questions.Delete(question);
                _unitOfWork.Save();
            }
        }

        public IEnumerable<QuestionVM> GetAll()
        {
            return _unitOfWork.Questions.GetAll()
                .Select(x => new QuestionVM { QuestionId = x.QuestionId, Text = x.Text, Score = x.Score, TestId = x.TestId, Test = x.Test.Name });
        }

        public QuestionVM GetById(int id)
        {
            Question question = _unitOfWork.Questions.GetById(id);

            return new QuestionVM { QuestionId = question.QuestionId, Text = question.Text, Score = question.Score, TestId = question.TestId, Test = question.Test.Name };
        }


        public void Update(QuestionVM model)
        {
            _unitOfWork.Questions.Update(new Question { QuestionId = model.QuestionId, Text = model.Text, Score = model.Score, TestId = model.TestId });
            _unitOfWork.Save();
        }
    }
}
