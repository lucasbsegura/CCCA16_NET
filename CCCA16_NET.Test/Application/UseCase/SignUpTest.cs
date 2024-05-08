using CCCA16_NET.Application.UseCase;
using CCCA16_NET.Infra.Database;
using CCCA16_NET.Infra.Gateway;
using CCCA16_NET.Infra.Repository;
using CCCA16_NET.Test.Helper;

namespace CCCA16_NET.Test.Application.UseCase
{
    public class SignUpTest
    {
        private readonly Random _randonNumber;
        private readonly IAccountRepository _accountRepository;
        private readonly IMailerGateway _mailerGateway;

        public SignUpTest()
        {
            //var dbService = new DbService(FakeConfigurationBuilder.Do());
            //_accountRepository = new AccountRepository(dbService);
            _accountRepository = new AccountRepositoryInMemory();
            _mailerGateway = new MailerGateway();
            _randonNumber = new Random();
        }

        [Fact]
        public async void DeveCriarContaParaPassageiro()
        {
            var input = new SignUpInput
            {
                Name = "John Doe",
                Email = $"john{_randonNumber.Next()}@gmail.com",
                Cpf = "87748248800",
                IsPassenger = true
            };
            var signUp = new SignUp(_accountRepository, _mailerGateway);
            var outputSignUp = await signUp.Execute(input);
            Assert.True(outputSignUp != Guid.Empty);
            var getAccount = new GetAccount(_accountRepository);
            var outputGetAccount = await getAccount.Execute(outputSignUp);
            Assert.True(input.Name == outputGetAccount.Name);
            Assert.True(input.Email == outputGetAccount.Email);
            Assert.True(input.Cpf == outputGetAccount.Cpf);
        }

        [Fact]
        public async void DeveCriarContaParaMotorista()
        {
            var input = new SignUpInput
            {
                Name = "John Doe",
                Email = $"john{_randonNumber.Next()}@gmail.com",
                Cpf = "87748248800",
                IsDriver = true,
                CarPlate = "0Y93D93"
            };
            var signUp = new SignUp(_accountRepository, _mailerGateway);
            var outputSignUp = await signUp.Execute(input);
            Assert.True(outputSignUp != Guid.Empty);
            var getAccount = new GetAccount(_accountRepository);
            var outputGetAccount = await getAccount.Execute(outputSignUp);
            Assert.True(input.Name == outputGetAccount.Name);
            Assert.True(input.Email == outputGetAccount.Email);
            Assert.True(input.Cpf == outputGetAccount.Cpf);
            Assert.True(input.CarPlate == outputGetAccount.CarPlate);
        }

        [Fact]
        public async void NaoDeveCriarContaSeEmailJaExiste()
        {
            var input = new SignUpInput
            {
                Name = "John Do",
                Email = $"john{_randonNumber.Next()}@gmail.com",
                Cpf = "35535244058",
                IsPassenger = true
            };
            var signUp = new SignUp(_accountRepository, _mailerGateway);
            var outputSignUp = await signUp.Execute(input);
            Task act() => signUp.Execute(input);
            Exception exception = await Assert.ThrowsAsync<Exception>(act);
            Assert.Equal("Account already exists", exception.Message);
        }

        [Fact]
        public async void NaoDeveCriarContaSeEmailInvalido()
        {
            var input = new SignUpInput
            {
                Name = "John Doe",
                Email = "john1.mail.com",
                Cpf = "11111111111",
                IsPassenger = true
            };
            var signUp = new SignUp(_accountRepository, _mailerGateway);
            Task act() => signUp.Execute(input);
            Exception exception = await Assert.ThrowsAsync<Exception>(act);
            Assert.Equal("Invalid email", exception.Message);
        }

        [Fact]
        public async void NaoDeveCriarContaSeCpfInvalido()
        {
            var input = new SignUpInput
            {
                Name = "John Doe",
                Email = $"john{_randonNumber.Next()}@gmail.com",
                Cpf = "11111111111",
                IsPassenger = true
            };
            var signUp = new SignUp(_accountRepository, _mailerGateway);
            Func<Task> act = () => signUp.Execute(input);
            Exception exception = await Assert.ThrowsAsync<Exception>(act);
            Assert.Equal("Invalid cpf", exception.Message);
        }
    }
}
