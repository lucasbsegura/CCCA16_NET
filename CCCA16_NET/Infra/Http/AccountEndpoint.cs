using CCCA16_NET.Application.UseCase;
using CCCA16_NET.Infra.Repository;

namespace CCCA16_NET.Infra.Http
{
    public static class AccountEndpoint
    {
        public static void Create(WebApplication app)
        {
            app.MapGet("/Account/{accountId}", Get);
        }

        private static async Task<AccountOutput> Get(Guid accountId, IAccountRepository accountRepository)
        {
            var getAccount = new GetAccount(accountRepository);
            return await getAccount.Execute(accountId);
        }
    }
}
