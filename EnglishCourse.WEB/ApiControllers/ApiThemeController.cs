using System.Collections.Generic;
using System.Linq;
using EnglishCourse.Logic.Interfaces;
using EnglishCourse.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnglishCourse.WEB.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ApiThemeController : ControllerBase
    {
        private readonly IThemeService _themeService;

        public ApiThemeController(IThemeService themeService)
        {
            _themeService = themeService;
        }

        [HttpGet]
        public IEnumerable<ThemeVM> GetThemes()
        {
            return _themeService.GetAll();
        }

        [HttpPost]
        public IActionResult Post([FromBody]ThemeVM model)
        {
            ThemeVM theme = _themeService.GetAll().Where(x => x.Name == model.Name).FirstOrDefault();

            if(theme != null)
            {
                ModelState.AddModelError(string.Empty, "Theme is already exists");

                return BadRequest(ModelState);
            }

            _themeService.Create(model);

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ThemeVM theme = _themeService.GetAll().FirstOrDefault(x => x.ThemeId == id);

            if (theme == null)
            {
                return NotFound();
            }
  
            return new ObjectResult(theme);
        }

        [HttpPut]
        public IActionResult Put([FromBody]ThemeVM model)
        {
            ThemeVM theme = _themeService.GetAll().Where(x => x.Name == model.Name && x.Description == model.Description).FirstOrDefault();

            if (theme != null)
            {
                ModelState.AddModelError(string.Empty, "Data not change");

                return BadRequest(ModelState);
            }

            _themeService.Update(model);

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ThemeVM theme = _themeService.GetById(id);

            if (theme == null)
            {
                return NotFound();
            }

            _themeService.Delete(theme.ThemeId);

            return Ok(theme);
        }
    }
}