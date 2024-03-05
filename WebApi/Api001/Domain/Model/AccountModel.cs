namespace Api001.Domain.Model
{
    public class AccountModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }

        public DTO.AccountDTO ToDTO()
        {
            return new DTO.AccountDTO
            {
                Id = this.Id,
                Name = this.Name,
                Balance = this.Balance
            };
        }
    }
}
