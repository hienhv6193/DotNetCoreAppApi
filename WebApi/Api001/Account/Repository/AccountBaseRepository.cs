using Api001.DB;
using Api001.Domain.Account;
using Api001.Domain.DTO;

namespace Api001.Account.Repository
{
    public class AccountBaseRepository : AccountRepository
    {
        private readonly AccountContext _context;
        public AccountBaseRepository(AccountContext context)
        {
            _context = context;
        }
        public Task Create(AccountDTO account)
        {
            this._context.Accounts.Add(account.ToModel());
            return this._context.SaveChangesAsync();
        }

        public Task Delete(string id)
        {
            this._context.Accounts.Remove(this._context.Accounts.SingleOrDefault(a => a.Id == id));
            return this._context.SaveChangesAsync();
        }

        public Task GetAll()
        {
            this._context.Accounts.ToList();
            return Task.CompletedTask;
        }

        public Task<AccountDTO?> GetById(string id)
        {
            var result = this._context.Accounts.SingleOrDefault(a => a.Id == id);
            return Task.FromResult<AccountDTO?>(result?.ToDTO());
        }

        public Task Update(AccountDTO account)
        {
            this._context.Accounts.Update(account.ToModel());
            return this._context.SaveChangesAsync();
        }
    }
}
