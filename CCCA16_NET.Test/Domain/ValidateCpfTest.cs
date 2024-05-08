using CCCA16_NET.Domain;

namespace CCCA16_NET.Test.Domain
{
    public class ValidateCpfTest
    {
        [Theory]
        [InlineData("97456321558")]
        [InlineData("71428793860")]
        [InlineData("87748248800")]
        public void DeveTestarUmCpfValido(string cpf)
        {
            var validateCpf = new ValidateCpf();
            Assert.True(validateCpf.Validate(cpf) == true);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("123")]
        [InlineData("11111111111")]
        [InlineData("1234566789123456789")]
        public void DeveTestarCpfInvalido(string cpf)
        {
            var validateCpf = new ValidateCpf();
            Assert.True(validateCpf.Validate(cpf) == false);
        }
    }
}
