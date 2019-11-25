using EnglishCourse.DataProvider.Context;
using EnglishCourse.DataProvider.Entities;
using EnglishCourse.DataProvider.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EnglishCourse.DataProvider.Repository
{
    public class TestRepository : ITestRepository
    {
        private readonly DatabaseContext _context;

        public TestRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Create(Test entity)
        {
            _context.Tests.Add(entity);
        }

        public void Delete(Test entity)
        {
            _context.Tests.Remove(entity);
        }

        public IEnumerable<Test> GetAll()
        {
            return _context.Tests.Include(x => x.Theme);
        }

        public Test GetById(int id)
        {
            return _context.Tests.Where(x => x.TestId == id).Include(x => x.Theme).FirstOrDefault();
        }

        public void Update(Test entity)
        {
            Test test = _context.Tests.Find(entity.TestId);

            if(test != null)
            {
                test.TestId = entity.TestId;
                test.Name = entity.Name;
                test.ThemeId = entity.ThemeId;
            }
        }
    }
}
