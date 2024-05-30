using CCCA16_NET.Domain.Vo;

namespace CCCA16_NET.Test.Domain.Vo
{
    public class CpfTest
    {
        [Theory]
        [InlineData("97456321558")]
        [InlineData("71428793860")]
        [InlineData("87748248800")]
        public void DeveTestarUmCpfValido(string cpf)
        {
            var validateCpf = new Cpf(cpf);
            Assert.True(validateCpf != null);
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
            Assert.Throws<Exception>(() => new Cpf(cpf));
        }
    }
}
