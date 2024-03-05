namespace Api001.Domain.Account
{
    public class AccountExceptions
    {
        public class AccountNotFoundException : Exception
        {
            public AccountNotFoundException(string id) : base($"Account with id {id} not found")
            {
            }
        }

        public class AccountInvalidException : Exception
        {
            public AccountInvalidException(string message) : base(message)
            {
            }
        }
        public class AccountExistsException : Exception
        {
            public AccountExistsException(string id) : base($"Account with id {id} already exists")
            {
            }
        }
    }
}
