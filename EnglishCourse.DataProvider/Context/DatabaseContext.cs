using EnglishCourse.DataProvider.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnglishCourse.DataProvider.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}
