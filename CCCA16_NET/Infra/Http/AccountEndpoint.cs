using CCCA16_NET.Domain.Entity;
using CCCA16_NET.Infra.Repository;

namespace CCCA16_NET.Infra.Http
{
    public static class AccountEndpoint
    {
        public static void Create(WebApplication app)
        {
            app.MapGet("/Account/{accountId}", Get);
        }

        public static async Task<Account> Get(Guid accountId, IAccountRepository accountRepository)
        {
            var getAccount = new Application.UseCase.GetAccount(accountRepository);
            return await getAccount.Execute(accountId);
        }
    }
}
