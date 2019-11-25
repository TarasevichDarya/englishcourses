using EnglishCourse.DataProvider.Context;
using EnglishCourse.DataProvider.Entities;
using EnglishCourse.DataProvider.Interfaces;
using System.Collections.Generic;

namespace EnglishCourse.DataProvider.Repository
{
    public class ThemeRepository : IThemeRepository
    {
        //dependency injection
        private readonly DatabaseContext _context;

        public ThemeRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Create(Theme entity)
        {
            _context.Themes.Add(entity);
        }

        public void Delete(Theme entity)
        {
            _context.Themes.Remove(entity);
        }

        public IEnumerable<Theme> GetAll()
        {
            return _context.Themes;
        }

        public Theme GetById(int id)
        {
            return _context.Themes.Find(id);
        }

        public void Update(Theme entity)
        {
            Theme theme = _context.Themes.Find(entity.ThemeId);

            if(theme != null)
            {
                theme.ThemeId = entity.ThemeId;
                theme.Name = entity.Name;
                theme.Description = entity.Description;
            }
        }
    }
}
