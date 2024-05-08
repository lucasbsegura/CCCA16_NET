namespace CCCA16_NET.Infra.Gateway
{
    public interface IMailerGateway
    {
        void Send(string recipient, string subject, string content);
    }
    public class MailerGateway : IMailerGateway
    {
        public void Send(string recipient, string subject, string content)
        {
            Console.WriteLine($"{recipient}, {subject}, {content}");
        }
    }
}
