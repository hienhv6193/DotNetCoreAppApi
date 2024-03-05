using Api001.Domain.DTO;

namespace Api001.Domain.Account
{
    public interface AccountInterop
    {
        Task GetAll(string token);
        Task Create(string token,AccountDTO account);
        Task<AccountDTO?> GetById(string token, string id);
        Task Update(string token, AccountDTO account);
        Task Delete(string token, string id);
    }
}
