using Api001.Domain.Account;
using Api001.Domain.DTO;

namespace Api001.Account.Repository
{
    public class InMemRepository : AccountRepository
    {
        private Dictionary<string, AccountDTO> db;
        public InMemRepository()
        {
            this.db = new Dictionary<string, AccountDTO>();
        }

        public Task GetAll()
        {
            return Task.FromResult(this.db.Values);
        }

        public Task Create(AccountDTO account)
        {
            this.db.Add(account.Id, account);
            return Task.CompletedTask;
        }

        public Task<AccountDTO?> GetById(string id)
        {
            if(this.db.TryGetValue(id, out var value))
            {
                return Task.FromResult<AccountDTO?>(value);
            }
            return Task.FromResult<AccountDTO?>(null);
        }

        public Task Update(AccountDTO account)
        {
            this.db[account.Id] = account;
            return Task.CompletedTask;
        }

        public Task Delete(string id)
        {
            this.db.Remove(id);
            return Task.CompletedTask;
        }
    }
}
