using Api001.Domain.DTO;

namespace Api001.Domain.Account
{
    public interface AccountUseCase
    {
        Task GetAll();
        Task Create(AccountDTO account);
        Task<AccountDTO?> GetById(string id);
        Task Update(AccountDTO account);
        Task Delete(string id);
    }
}
