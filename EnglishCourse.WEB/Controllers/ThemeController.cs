using EnglishCourse.Logic.Interfaces;
using EnglishCourse.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnglishCourse.WEB.Controllers
{
    public class ThemeController : Controller
    {
        private readonly IThemeService _themeService;

        public ThemeController(IThemeService themeService)
        {
            _themeService = themeService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(new ThemeVM());
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            ThemeVM theme = _themeService.GetById(id);

            return View(theme);
        }

        //[Authorize(Roles = "User")]
        //public IActionResult Favorite(int id)
        //{
        //    ThemeVM theme = _themeService.GetById(id);

        //    return View(theme);
        //}
    }
}