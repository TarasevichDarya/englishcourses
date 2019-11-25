using EnglishCourse.Logic.Interfaces;
using EnglishCourse.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EnglishCourse.WEB.Controllers
{
    [Authorize(Roles = "Admin")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionRepository;
        private readonly ITestService _testRepository;

        public QuestionController(IQuestionService questionRepository, ITestService testRepository)
        {
            _questionRepository = questionRepository;
            _testRepository = testRepository;
        }

        public IActionResult Index()
        {
            return View(_questionRepository.GetAll());
        }

        public IActionResult Create()
        {
            ViewBag.TestList = _testRepository.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Create(QuestionVM model)
        {
            if (ModelState.IsValid)
            {
                var question = _questionRepository.GetAll().Where(x => x.TestId == model.TestId && x.Text == model.Text).FirstOrDefault();

                if (question == null)
                {
                    _questionRepository.Create(model);

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "This question is already exists");
                }
            }

            ViewBag.TestList = _testRepository.GetAll();

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            QuestionVM question = _questionRepository.GetById(id);

            ViewBag.TestList = _testRepository.GetAll();

            return View(question);
        }

        [HttpPost]
        public IActionResult Edit(QuestionVM model)
        {
            if (ModelState.IsValid)
            {
                var question = _questionRepository.GetAll().Where(x => x.TestId == model.TestId && x.Text == model.Text && x.Score == model.Score).FirstOrDefault();

                if (question == null)
                {
                    _questionRepository.Update(model);

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Data not changed");
                }
            }

            ViewBag.TestList = _testRepository.GetAll();

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            QuestionVM question = _questionRepository.GetById(id);

            return View(question);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            QuestionVM question = _questionRepository.GetById(id);

            _questionRepository.Delete(question.QuestionId);

            return RedirectToAction("Index");
        }
    }
}