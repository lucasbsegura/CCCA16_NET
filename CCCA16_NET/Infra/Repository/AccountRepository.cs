using CCCA16_NET.Domain.Entity;
using CCCA16_NET.Infra.Database;

namespace CCCA16_NET.Infra.Repository
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountByEmail(string email);
        Task<Account> GetAccountById(Guid id);
        void SaveAccount(Account account);
    }

    public class AccountRepository : IAccountRepository
    {
        private readonly IDbService _connection;
        public AccountRepository(IDbService connection)
        {
            _connection = connection;
        }

        public async Task<Account> GetAccountByEmail(string email)
        {
            var account = await _connection.GetAsync<Account>("select * from cccat16.account where email = @email", new { email });
            return account;
        }

        public async Task<Account> GetAccountById(Guid id)
        {
            return await _connection.GetAsync<Account>("select account_id AS AccountId, name, email, cpf, car_plate AS CarPlate, is_passenger AS IsPassenger, is_driver AS IsDriver from cccat16.account where account_id = @id", new { id });
        }

        public async void SaveAccount(Account account)
        {
            var result = await _connection.EditData(
            "INSERT INTO cccat16.account (account_id, name, email, cpf, car_plate, is_passenger, is_driver) " +
            "VALUES (@AccountId, @Name, @Email, @Cpf, @CarPlate, @IsPassenger, @IsDriver)",
            account);
        }
    }

    public class AccountRepositoryInMemory : IAccountRepository
    {
        private readonly List<Account> _accounts;
        public AccountRepositoryInMemory()
        {
            _accounts = new List<Account>();
        }

        public async Task<Account> GetAccountByEmail(string email)
        {
            var account = _accounts.Where(a => a.Email == email).FirstOrDefault();
            return account;
        }

        public async Task<Account> GetAccountById(Guid id)
        {
            var account = _accounts.Where(a => a.AccountId == id).FirstOrDefault();
            return account;
        }

        public void SaveAccount(Account account)
        {
            _accounts.Add(account);
        }
    }
}
