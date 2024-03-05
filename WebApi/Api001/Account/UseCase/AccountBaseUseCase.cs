using Api001.Domain.Account;
using Api001.Domain.DTO;

namespace Api001.Account.UseCase
{
    public class AccountBaseUseCase : AccountUseCase
    {
        private readonly AccountRepository _repository;
        public AccountBaseUseCase(AccountRepository repository)
        {
            _repository = repository;
        }

        public Task GetAll()
        {
            return this._repository.GetAll();
        }
        public Task Create(AccountDTO account)
        {
            Validate(account);
            var existingAccount = this._repository.GetById(account.Id);
            if(existingAccount.Result != null)
            {
                throw new AccountExceptions.AccountExistsException(account.Id);
            }
            return this._repository.Create(account);
        }

        public Task<AccountDTO?> GetById(string id)
        {
            return this._repository.GetById(id);
        }

        public Task Update(AccountDTO account)
        {
            Validate(account);
            return this._repository.Update(account);
        }

        public Task Delete(string id)
        {
            return this._repository.Delete(id);
        }

        private void Validate(AccountDTO account)
        {
            if(account.Id == "")
            {
                throw new AccountExceptions.AccountInvalidException(message: "Id is required");
            }
            if(account.Name == "")
            {
                throw new AccountExceptions.AccountInvalidException(message: "Name is required");
            }
            if(account.Balance < 0)
            {
                throw new AccountExceptions.AccountInvalidException(message: "Balance must be greater than or equal to 0");
            }
        }
    }
}
