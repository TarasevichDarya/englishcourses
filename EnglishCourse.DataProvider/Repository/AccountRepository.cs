using EnglishCourse.Common.Crypto;
using EnglishCourse.DataProvider.Context;
using EnglishCourse.DataProvider.Entities;
using EnglishCourse.DataProvider.Interfaces;
using System.Linq;

namespace EnglishCourse.DataProvider.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DatabaseContext _context;

        public AccountRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Account GetByName(string email)
        {
            if (email != null)
            {
                return _context.Accounts.Where(x => x.Email == email).FirstOrDefault();
            }

            return new Account();
        }

        public string GetRole(string email)
        {
            if(email != null)
            {
                return _context.Accounts.Where(x => x.Email == email).FirstOrDefault().Role;
            }

            return "";
        }

        public bool IsExists(string email)
        {
            return _context.Accounts.Where(x => x.Email == email).FirstOrDefault() != null ? true : false;
        }

        public bool Login(string email, string password)
        {
            string passwordHash = Crypto.Sha256(password + email);

            return _context.Accounts.Where(x=> x.Email == email && x.Password == passwordHash).FirstOrDefault() != null ? true : false;
        }

        public void Registration(Account entity)
        {
            _context.Accounts.Add(new Account()
            {
                Name = entity.Name,
                Surname = entity.Surname,
                Email = entity.Email,
                Password = Crypto.Sha256(entity.Password + entity.Email),
                Role = "User"
            });
        }

        public void Update(Account entity)
        {
            Account account = _context.Accounts.Find(entity.AccountId);

            if(account != null)
            {
                account.Name = entity.Name;
                account.Surname = entity.Surname;
            }
        }
    }
}
