using System.Net.Mail;

namespace CCCA16_NET.Domain.Vo
{
    public class Email
    {
        private string Value { get; set; }

        public Email(string email) 
        {
            if (!this.IsValid(email)) throw new Exception("Invalid email");
            this.Value = email;
        }

        private bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public string GetValue()
        {
            return this.Value;
        }
    }
}
