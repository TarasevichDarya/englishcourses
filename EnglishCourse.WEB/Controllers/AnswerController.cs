using System.Linq;
using EnglishCourse.Logic.Interfaces;
using EnglishCourse.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnglishCourse.WEB.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AnswerController : Controller
    {
        private readonly IAnswerService _answerService;
        private readonly IQuestionService _questionService;
        
        public AnswerController(IAnswerService answerService, IQuestionService questionService)
        {
            _answerService = answerService;
            _questionService = questionService;
        }

        public IActionResult Index()
        {
            return View(_answerService.GetAll());
        }

        public IActionResult Create()
        {
            ViewBag.QuestionList = _questionService.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Create(AnswerVM model)
        {
            if (ModelState.IsValid)
            {
                var answer = _answerService.GetAll().Where(x => x.QuestionId == model.QuestionId && x.Text == model.Text).FirstOrDefault();

                if(answer == null)
                {
                    int count = _answerService.GetAll().Where(x => x.QuestionId == model.QuestionId && x.IsRight == true && x.IsRight == model.IsRight).Count();

                    if (count == 0)
                    {
                        _answerService.Create(model);

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "The right answer to this question already has!");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "The answer to this question already has!");
                }                
            }

            ViewBag.QuestionList = _questionService.GetAll();

            return View();
        }

        public IActionResult Delete(int id)
        {
            AnswerVM answer = _answerService.GetById(id);

            return View(answer);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            AnswerVM answer = _answerService.GetById(id);

            _answerService.Delete(answer.AnswerId);

            return RedirectToAction("Index");
        }
    }
}