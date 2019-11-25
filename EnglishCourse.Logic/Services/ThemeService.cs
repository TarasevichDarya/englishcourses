using EnglishCourse.DataProvider.Entities;
using EnglishCourse.DataProvider.Interfaces;
using EnglishCourse.Logic.Interfaces;
using EnglishCourse.Model.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace EnglishCourse.Logic.Services
{
    public class ThemeService : IThemeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ThemeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(ThemeVM model)
        {
            _unitOfWork.Themes.Create(new Theme { Name = model.Name, Description = model.Description });
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            Theme theme = _unitOfWork.Themes.GetById(id);

            if(theme != null)
            {
                _unitOfWork.Themes.Delete(theme);
                _unitOfWork.Save();
            }
        }

        public IEnumerable<ThemeVM> GetAll()
        {
            return _unitOfWork.Themes.GetAll()
                .Select(x => new ThemeVM { ThemeId = x.ThemeId, Name = x.Name, Description = x.Description });
        }

        public ThemeVM GetById(int id)
        {
            Theme theme = _unitOfWork.Themes.GetById(id);

            return new ThemeVM { ThemeId = theme.ThemeId, Name = theme.Name, Description = theme.Description };
        }

        public void Update(ThemeVM model)
        {
            _unitOfWork.Themes.Update(new Theme { ThemeId = model.ThemeId, Name = model.Name, Description = model.Description });

            _unitOfWork.Save();
        }
    }
}
