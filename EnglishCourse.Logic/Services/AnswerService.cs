using System.Collections.Generic;
using System.Linq;
using EnglishCourse.DataProvider.Entities;
using EnglishCourse.DataProvider.Interfaces;
using EnglishCourse.Logic.Interfaces;
using EnglishCourse.Model.ViewModels;

namespace EnglishCourse.Logic.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnswerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(AnswerVM model)
        {
            _unitOfWork.Answers.Create(new Answer { Text = model.Text, IsRight = model.IsRight, QuestionId = model.QuestionId });
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            Answer answer = _unitOfWork.Answers.GetById(id);

            if (answer != null)
            {
                _unitOfWork.Answers.Delete(answer);
                _unitOfWork.Save();
            }
        }

        public IEnumerable<AnswerVM> GetAll()
        {
            return _unitOfWork.Answers.GetAll()
                .Select(x => new AnswerVM { AnswerId = x.AnswerId, Text = x.Text, IsRight = x.IsRight, QuestionId = x.QuestionId, Question = x.Question.Text });
        }

        public AnswerVM GetById(int id)
        {
            Answer answer = _unitOfWork.Answers.GetById(id);

            return new AnswerVM { AnswerId = answer.AnswerId, Text = answer.Text, IsRight = answer.IsRight, QuestionId = answer.QuestionId, Question = answer.Question.Text };
        }

        public void Update(AnswerVM model)
        {
            _unitOfWork.Answers.Update(new Answer { AnswerId = model.AnswerId, Text = model.Text, IsRight = model.IsRight, QuestionId = model.QuestionId });
            _unitOfWork.Save();
        }
    }
}
