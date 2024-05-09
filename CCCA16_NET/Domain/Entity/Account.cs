using CCCA16_NET.Domain.Vo;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace CCCA16_NET.Domain.Entity
{
    public class Account
    {
        [Column("account_id")]
        public Guid AccountId { get; }
        public string Name { get; }
        public string Email { get; }
        public Cpf Cpf { get; }
        [Column("car_plate")]
        public string CarPlate { get; }
        [Column("is_passenger")]
        public bool IsPassenger { get; }
        [Column("is_driver")]
        public bool IsDriver { get; }

        private Account(Guid accountId, string name, string email, Cpf cpf, string carPlate, bool isPassenger, bool isDriver)
        {
            //var validateCpf = new ValidateCpf();
            var validateEmail = new ValidateEmail();

            if (Regex.IsMatch(name, "/[a-zA-Z] [a-zA-Z]+/")) throw new Exception("Invalid name");
            if (!validateEmail.IsValid(email)) throw new Exception("Invalid email");
            //if (!validateCpf.Validate(cpf)) throw new Exception("Invalid cpf");
            if (isDriver && string.IsNullOrEmpty(carPlate)) throw new Exception("Invalid car plate");

            AccountId = accountId;
            Name = name;
            Email = email;
            Cpf = cpf;
            CarPlate = carPlate;
            IsPassenger = isPassenger;
            IsDriver = isDriver;
        }

        public static Account Create(string name, string email, Cpf cpf, string carPlate, bool isPassenger, bool isDriver)
        {
            Guid accountId = Guid.NewGuid();
            return new Account(accountId, name, email, cpf, carPlate, isPassenger, isDriver);
        }

        public static Account Restore(Guid accountId, string name, string email, Cpf cpf, string carPlate, bool isPassenger, bool isDriver)
        {
            return new Account(accountId, name, email, cpf, carPlate, isPassenger, isDriver);
        }
    }
}
