using EnglishCourse.DataProvider.Entities;
using EnglishCourse.DataProvider.Interfaces;
using EnglishCourse.Logic.Interfaces;
using EnglishCourse.Model.ViewModels;

namespace EnglishCourse.Logic.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public AccountVM GetByName(string email)
        {
            if(email != null)
            {
                Account account = _unitOfWork.Accounts.GetByName(email);

                return new AccountVM { Name = account.Name, Surname = account.Surname, Email = account.Email, Password = account.Password, Role = account.Role, AccountId = account.AccountId };
            }

            return new AccountVM();
        }

        public string GetRole(string email)
        {
            if(email != null)
            {
                return _unitOfWork.Accounts.GetRole(email);
            }

            return "";
        }

        public LoginVM Login(LoginVM model)
        {
            if(!_unitOfWork.Accounts.Login(model.Email, model.Password))
            {
                return new LoginVM { Message = "Incorrect login or password" };
            }

            return model;
        }

        public RegisterVM Registration(RegisterVM model)
        {
            if (_unitOfWork.Accounts.IsExists(model.Email))
            {
                return new RegisterVM() { Message = "User with the same login is already exist" };
            }

            _unitOfWork.Accounts.Registration(new Account() { Name = model.Name, Surname = model.Surname, Email = model.Email, Password = model.Password, Role = "User" });

            _unitOfWork.Save();

            return model;
        }

        public void Update(AccountVM model)
        {
            _unitOfWork.Accounts.Update(new Account() { AccountId = model.AccountId, Email = model.Email, Name = model.Name, Password = model.Password, Role = model.Role, Surname = model.Surname });
            _unitOfWork.Save();
        }
    }
}
