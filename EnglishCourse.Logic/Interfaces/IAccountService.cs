using EnglishCourse.Model.ViewModels;

namespace EnglishCourse.Logic.Interfaces
{
    public interface IAccountService
    {
        AccountVM GetByName(string email);

        LoginVM Login(LoginVM model);

        RegisterVM Registration(RegisterVM model);

        string GetRole(string email);

        void Update(AccountVM model);
    }
}
