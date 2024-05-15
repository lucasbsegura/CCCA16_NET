using CCCA16_NET.Infra.Repository;

namespace CCCA16_NET.Application.UseCase
{
    public class GetAccount(IAccountRepository accountRepository)
    {
        private readonly IAccountRepository _accountRepository = accountRepository;

        public async Task<AccountOutput> Execute(Guid accountId)
        {
            var account = await _accountRepository.GetAccountById(accountId);
            return new AccountOutput(account.AccountId, 
                                     account.Name.GetValue(), 
                                     account.Email.GetValue(),
                                     account.Cpf.GetValue(),
                                     account.CarPlate.GetValue(),
                                     account.IsPassenger,
                                     account.IsDriver);
        }
    }

    public record AccountOutput(Guid AccountId, string Name, string Email, string Cpf, string CarPlate, bool IsPassenger, bool IsDriver)
    {
        public Guid AccountId { get; } = AccountId;
        public string Name { get; } = Name;
        public string Email { get; } = Email;
        public string Cpf { get; } = Cpf;
        public string CarPlate { get; } = CarPlate;
        public bool IsPassenger { get; } = IsPassenger;
        public bool IsDriver { get; } = IsDriver;
    }
}
