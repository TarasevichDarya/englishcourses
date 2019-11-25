using EnglishCourse.DataProvider.Context;
using EnglishCourse.DataProvider.Entities;
using EnglishCourse.DataProvider.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EnglishCourse.DataProvider.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DatabaseContext _context;

        public QuestionRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Create(Question entity)
        {
            _context.Questions.Add(entity);
        }

        public void Delete(Question entity)
        {
            _context.Questions.Remove(entity);
        }

        public IEnumerable<Question> GetAll()
        {
            return _context.Questions.Include(x => x.Test);
        }

        public Question GetById(int id)
        {
            return _context.Questions.Where(x => x.QuestionId == id).Include(x => x.Test).FirstOrDefault();
        }

        public void Update(Question entity)
        {
            Question question = _context.Questions.Find(entity.QuestionId);

            if(question != null)
            {
                question.QuestionId = entity.QuestionId;
                question.Text = entity.Text;
                question.Score = entity.Score;
                question.TestId = entity.TestId;
            }
        }
    }
}
