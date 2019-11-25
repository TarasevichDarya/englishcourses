using EnglishCourse.DataProvider.Entities;
using EnglishCourse.DataProvider.Interfaces;
using EnglishCourse.Logic.Interfaces;
using EnglishCourse.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishCourse.Logic.Services
{
    public class ResultService : IResultService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResultService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(ResultVM model)
        {
            _unitOfWork.Results.Create(new Result { TimeStart = model.TimeStart, TotalScore = model.TotalScore, AccountId = model.AccountId, TestId = model.TestId });
            _unitOfWork.Save();
        }

        public IEnumerable<ResultVM> GetAll()
        {
            return _unitOfWork.Results.GetAll()
                .Select(x => new ResultVM { ResultId = x.ResultId, TimeStart = x.TimeStart, TotalScore = x.TotalScore, AccountId = x.AccountId, TestId = x.TestId, Test = x.Test.Name });
        }
    }
}
