using System.Collections.Generic;
using System.Linq;
using EnglishCourse.DataProvider.Context;
using EnglishCourse.DataProvider.Entities;
using EnglishCourse.DataProvider.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnglishCourse.DataProvider.Repository
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly DatabaseContext _context;

        public AnswerRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Create(Answer entity)
        {
            _context.Answers.Add(entity);
        }

        public void Delete(Answer entity)
        {
            _context.Answers.Remove(entity);
        }

        public IEnumerable<Answer> GetAll()
        {
            return _context.Answers.Include(x => x.Question);
        }

        public Answer GetById(int id)
        {
            return _context.Answers.Include(x => x.Question).Where(x => x.AnswerId == id).FirstOrDefault();
        }

        public void Update(Answer entity)
        {
            Answer answer = _context.Answers.Find(entity.AnswerId);

            if (answer != null)
            {
                answer.AnswerId = entity.AnswerId;
                answer.Text = entity.Text;
                answer.IsRight = entity.IsRight;
                answer.QuestionId = entity.QuestionId;
            }
        }
    }
}
