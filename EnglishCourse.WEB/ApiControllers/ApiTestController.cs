using System.Collections.Generic;
using System.Linq;
using EnglishCourse.Logic.Interfaces;
using EnglishCourse.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

//        [ApiExplorerSettings(IgnoreApi = true)]  -- чтобы метод не добавлять в документацию

namespace EnglishCourse.WEB.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ApiTestController : ControllerBase
    {
        private readonly ITestService _testService;

        public ApiTestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public IEnumerable<TestVM> GetTests()
        {
            return _testService.GetAll();
        }

        [HttpPost]
        public IActionResult Post([FromBody]TestVM model)
        {
            TestVM test = _testService.GetAll().Where(x => x.Name == model.Name && x.ThemeId == model.ThemeId).FirstOrDefault();

            if(test != null)
            {
                ModelState.AddModelError(string.Empty, "This test has this theme already");

                return BadRequest(ModelState);
            }

            _testService.Create(model);

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            TestVM test = _testService.GetById(id);

            if (test == null)
            {
                return NotFound();
            }

            return new ObjectResult(test);
        }
        
        [HttpPut]
        public IActionResult Put([FromBody]TestVM model)
        {
            TestVM test = _testService.GetAll().Where(x => x.Name == model.Name && x.ThemeId == model.ThemeId).FirstOrDefault();

            if (test != null)
            {
                ModelState.AddModelError(string.Empty, "This test has this theme already");

                return BadRequest(ModelState);
            }

            _testService.Update(model);

            return Ok(model);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TestVM test = _testService.GetById(id);

            if (test == null)
            {
                return NotFound();
            }

            _testService.Delete(test.TestId);

            return Ok(test);
        }
    }
}