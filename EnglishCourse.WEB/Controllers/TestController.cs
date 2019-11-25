using EnglishCourse.Logic.Interfaces;
using EnglishCourse.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EnglishCourse.WEB.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TestController : Controller
    {
        private readonly IThemeService _themeService;
        private readonly ITestService _testService;

        public TestController(IThemeService themeService, ITestService testService)
        {
            _themeService = themeService;
            _testService = testService;
        }

        public IActionResult Index()
        {
            IEnumerable<ThemeVM> themes = _themeService.GetAll();
            ViewBag.ThemeList = themes;

            return View(new TestVM());
        }
    }
}