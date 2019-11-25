using EnglishCourse.DataProvider.Context;
using EnglishCourse.DataProvider.Entities;
using EnglishCourse.DataProvider.Interfaces;
using EnglishCourse.DataProvider.Repository;
using EnglishCourse.Logic.Interfaces;
using EnglishCourse.Logic.Services;
using EnglishCourse.Model.ViewModels;
using EnglishCourse.WEB.ApiControllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace EnglishCourse.Test
{
    public class UnitTest1
    {
        private readonly DatabaseContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IThemeService _themeService;
        private readonly ApiThemeController _controller;

        public UnitTest1()
        {
            var option = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "EnglishCourse")
                .Options;

            _context = new DatabaseContext(option);

            Seed(_context);

            _unitOfWork = new UnitOfWork(_context);
            _themeService = new ThemeService(_unitOfWork);
            _controller = new ApiThemeController(_themeService);
        }
        //----GET ALL
        [Fact]
        public void GetAllEqual()
        {
            var countThemes = _controller.GetThemes().Count();

            var y = 2;

            Assert.Equal(countThemes, y);
        }

        

        //-----Remove
        [Fact]
        public void Remove_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingId = 1000;

            // Act
            var badResponse = _controller.Delete(notExistingId);

            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var existingId = 1;

            // Act
            var okResponse = _controller.Delete(existingId);

            // Assert
            Assert.IsType<OkObjectResult>(okResponse);
        }

        [Fact]
        public void Test1()
        {
            var controller = new ApiThemeController(_themeService);

            var countTheme = controller.GetThemes().Count();

            var y = 5;

            Assert.NotEqual(countTheme, y);
        }

        [Fact]
        public void Test2()
        {
            var controller = new ApiThemeController(_themeService);
            ThemeVM theme = _themeService.GetAll().FirstOrDefault(x => x.ThemeId == 1);

        }

        [Fact]
        public void Test3()
        {
            var controller = new ApiThemeController(_themeService);

            var countTheme = controller.Delete(2);
        }

        private void Seed(DatabaseContext context)
        {
            var themes = new[]
            {
                new Theme {Name = "t1", Description = "d1"},
                new Theme {Name = "t2", Description = "d2"}
            };

            context.Themes.AddRange(themes);
            context.SaveChanges();
        }
    }
}
