namespace Api001.Domain.DTO
{
    public class AccountDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }

        public Model.AccountModel ToModel()
        {
            return new Model.AccountModel
            {
                Id = this.Id,
                Name = this.Name,
                Balance = this.Balance
            };
        }
    }
}
