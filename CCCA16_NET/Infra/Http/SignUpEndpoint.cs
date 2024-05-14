using CCCA16_NET.Application.UseCase;
using CCCA16_NET.Infra.Gateway;
using CCCA16_NET.Infra.Repository;

namespace CCCA16_NET.Infra.Http
{
    public class SignUpEndpoint
    {
        public static void Create(WebApplication app)
        {
            app.MapPost("/SignUp", SignUp);
        }

        private static async Task<Guid> SignUp(SignUpInput signUpInput, IAccountRepository accountRepository, IMailerGateway mailerGateway)
        {
            var signUp = new SignUp(accountRepository, mailerGateway);
            return await signUp.Execute(signUpInput);
        }
    }
}
