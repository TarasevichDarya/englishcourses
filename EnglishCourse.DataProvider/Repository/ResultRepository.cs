using System.Collections.Generic;
using EnglishCourse.DataProvider.Context;
using EnglishCourse.DataProvider.Entities;
using EnglishCourse.DataProvider.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnglishCourse.DataProvider.Repository
{
    public class ResultRepository : IResultRepository
    {
        private readonly DatabaseContext _context;

        public ResultRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Create(Result entity)
        {
            _context.Results.Add(entity);
        }

        public IEnumerable<Result> GetAll()
        {
            return _context.Results.Include(x => x.Account).Include(x => x.Test);
        }
    }
}
