using EnglishCourse.Common.Crypto;
using EnglishCourse.DataProvider.Context;
using EnglishCourse.DataProvider.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EnglishCourse.DataProvider.Initializer
{
    public static class InitializerDB
    {
        public static void Initialize(DatabaseContext context)
        {
            IList<Account> defaultAccounts = new List<Account>();
            IList<Theme> defaultThemes = new List<Theme>();

            if (!context.Themes.Any())
            {
                defaultThemes.Add(new Theme { Name = "Theme1", Description = "Description1" });
                defaultThemes.Add(new Theme { Name = "Theme2", Description = "Description2" });
                defaultThemes.Add(new Theme { Name = "Theme3", Description = "Description3" });
                defaultThemes.Add(new Theme { Name = "Theme4", Description = "Description4" });
                defaultThemes.Add(new Theme { Name = "Theme5", Description = "Description5" });
                context.Themes.AddRange(defaultThemes);
            }

            if (!context.Accounts.Any())
            {
                defaultAccounts.Add(new Account { Name = "admin", Surname = "admin", Email = "admin@mail.ru", Password = Crypto.Sha256("admin" + "admin@mail.ru"), Role = "Admin" });
                context.Accounts.AddRange(defaultAccounts);
            }

            context.SaveChanges();
        }
    }
}
