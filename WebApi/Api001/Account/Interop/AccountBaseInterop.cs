using Api001.Domain.Account;
using Api001.Domain.DTO;

namespace Api001.Account.Interop
{
    public class AccountBaseInterop : AccountInterop
    {
        private readonly AccountUseCase _usecase;
        public AccountBaseInterop(AccountUseCase usecase)
        {
            this._usecase = usecase;
        }

        public Task GetAll(string token)
        {
            return this._usecase.GetAll();
        }
        public Task Create(string token, AccountDTO account)
        {
            return this._usecase.Create(account);
        }

        public Task<AccountDTO?> GetById(string token, string id)
        {
            return this._usecase.GetById(id);
        }

        public Task Update(string token, AccountDTO account)
        {
            return this._usecase.Update(account);
        }

        public Task Delete(string token, string id)
        {
            return this._usecase.Delete(id);
        }
    }
}
