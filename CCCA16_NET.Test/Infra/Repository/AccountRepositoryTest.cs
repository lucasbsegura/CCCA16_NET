using CCCA16_NET.Domain.Entity;
using CCCA16_NET.Domain.Vo;
using CCCA16_NET.Infra.Database;
using CCCA16_NET.Infra.Repository;
using CCCA16_NET.Test.Helper;

namespace CCCA16_NET.Test.Infra.Repository
{
    public class AccountRepositoryTest
    {
        private readonly Random _randonNumber;

        public AccountRepositoryTest() {
            _randonNumber = new Random();
        }

        [Fact]
        public async void DeveSalvarUmRegistroNaTabelaAccountEConsultarPorId()
        {
            var account = Account.Create("John Doe", $"john{_randonNumber.Next()}@gmail.com", "87748248800", "", true, false);

            var dbService = new DbService(FakeConfigurationBuilder.Do());
            dbService.Open();
            var accountRepository = new AccountRepository(dbService);
            accountRepository.SaveAccount(account);
            var accountById = await accountRepository.GetAccountById(account.AccountId);
            dbService.Close();
            Assert.True(accountById.AccountId == account.AccountId);
            Assert.True(accountById.Name.GetValue() == account.Name.GetValue());
            Assert.True(accountById.Email.GetValue() == account.Email.GetValue());
            Assert.True(accountById.Cpf.GetValue() == account.Cpf.GetValue());
        }
    }
}
