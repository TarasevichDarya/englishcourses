using EnglishCourse.Logic.Interfaces;
using EnglishCourse.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishCourse.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IThemeService _themeService;
        private readonly ITestService _testService;
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;
        private readonly IResultService _resultService;

        public HomeController(IAccountService accountService, IThemeService themeService, ITestService testService, IQuestionService questionService, IAnswerService answerService, IResultService resultService)
        {
            _accountService = accountService;
            _themeService = themeService;
            _testService = testService;
            _questionService = questionService;
            _answerService = answerService;
            _resultService = resultService;
        }

        [AllowAnonymous]
        public IActionResult Index(string searchType = null, string name = null)
        { 

            var homeVM = new HomeVM()
            {
                ThemeCount = _themeService.GetAll().Count(),
                TestCount = _testService.GetAll().Count(),
                QuestionCount = _questionService.GetAll().Count(),
                AnswerCount = _answerService.GetAll().Count()
            };

            IEnumerable<ThemeVM> themes = null;

            if (name != null)
            {
                switch (searchType)
                {
                    case "startWith":
                        themes = _themeService.GetAll().Where(x => x.Name.ToLower().StartsWith(name.ToLower()));
                        break;
                    case "endWith":
                        themes = _themeService.GetAll().Where(x => x.Name.ToLower().EndsWith(name.ToLower()));
                        break;
                    case "equal":
                        themes = _themeService.GetAll().Where(x => x.Name.ToLower().Equals(name.ToLower()));
                        break;
                    case "contains":
                        themes = _themeService.GetAll().Where(x => x.Name.ToLower().Contains(name.ToLower()));
                        break;
                }
            }
            else
            {
                themes = _themeService.GetAll();
            }

            ViewBag.ThemeList = themes;

            return View(homeVM);
        }

        [AllowAnonymous]
        public IActionResult Tests(int id)
        {
            IEnumerable<TestVM> tests = _testService.GetAll().Where(x => x.ThemeId == id);
            
            return View(tests);
        }

        [Authorize(Roles = "User")]
        public IActionResult Start(int id)
        {
            IEnumerable<QuestionVM> questions = _questionService.GetAll().Where(x => x.TestId == id);

            ViewBag.TestId = id;
            ViewBag.DateStart = DateTime.Now;

            return View(questions);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public JsonResult Result(List<string> values, int testId)
        {
            int countIsRightAnswer = 0;

            var questions = _questionService.GetAll().Where(x => x.TestId == testId).ToList();

            var totalScore = 0;

            for (int i = 0; i < questions.Count(); i++)
            {
                var answers = _answerService.GetAll().Where(x => x.QuestionId == questions[i].QuestionId && x.IsRight).ToList();

                for (int j = 0; j < answers.Count(); j++)
                {
                    for (int k = 0; k < values.Count; k++)
                    {
                        if (values[k] == answers[j].Text)
                        {
                            countIsRightAnswer++;
                            totalScore += questions[i].Score;
                            break;
                        }
                    }
                }
            }

            AccountVM account = _accountService.GetByName(User.Identity.Name);

            ResultVM result = new ResultVM { TimeStart = DateTime.Now, AccountId = account.AccountId, TestId = testId, TotalScore = totalScore };

            _resultService.Create(result);

            return Json(totalScore);
        }
    }
}