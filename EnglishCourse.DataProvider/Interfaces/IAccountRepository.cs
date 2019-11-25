using EnglishCourse.DataProvider.Entities;

namespace EnglishCourse.DataProvider.Interfaces
{
    public interface IAccountRepository
    {
        Account GetByName(string email);

        bool Login(string email, string password);

        void Registration(Account entity);

        bool IsExists(string email);

        string GetRole(string email);

        void Update(Account entity);
    }
}
