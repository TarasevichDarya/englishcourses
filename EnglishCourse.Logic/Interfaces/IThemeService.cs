using EnglishCourse.Model.ViewModels;
using System.Collections.Generic;

namespace EnglishCourse.Logic.Interfaces
{
    public interface IThemeService
    {
        IEnumerable<ThemeVM> GetAll();

        ThemeVM GetById(int id);

        void Create(ThemeVM model);

        void Update(ThemeVM model);

        void Delete(int id);
    }
}
