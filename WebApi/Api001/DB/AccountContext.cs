using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Api001.DB
{
    public class AccountContext : DbContext
    {
        public DbSet<Domain.Model.AccountModel> Accounts { get; set; }
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
            // Ensure the database is created
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=account.db");
        }
    }
}
