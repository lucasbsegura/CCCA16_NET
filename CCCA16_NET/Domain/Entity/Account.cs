using CCCA16_NET.Domain.Vo;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCCA16_NET.Domain.Entity
{
    public class Account
    {
        [Column("account_id")]
        public Guid AccountId { get; }
        public Name Name { get; }
        public Email Email { get; }
        public Cpf Cpf { get; }
        [Column("car_plate")]
        public CarPlate CarPlate { get; }
        [Column("is_passenger")]
        public bool IsPassenger { get; }
        [Column("is_driver")]
        public bool IsDriver { get; }

        private Account(Guid accountId, Name name, Email email, Cpf cpf, CarPlate carPlate, bool isPassenger, bool isDriver)
        {
            AccountId = accountId;
            Name = name;
            Email = email;
            Cpf = cpf;
            CarPlate = carPlate;
            IsPassenger = isPassenger;
            IsDriver = isDriver;
        }

        public static Account Create(string name, string email, string cpf, string carPlate, bool isPassenger, bool isDriver)
        {
            Guid accountId = Guid.NewGuid();
            return new Account(accountId, new Name(name), new Email(email), new Cpf(cpf), new CarPlate(carPlate), isPassenger, isDriver);
        }

        public static Account Restore(Guid accountId, string name, string email, string cpf, string carPlate, bool isPassenger, bool isDriver)
        {
            return new Account(accountId, new Name(name), new Email(email), new Cpf(cpf), new CarPlate(carPlate), isPassenger, isDriver);
        }
    }
}
