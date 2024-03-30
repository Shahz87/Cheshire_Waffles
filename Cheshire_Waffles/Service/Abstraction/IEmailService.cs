namespace Cheshire_Waffles.Service.Abstraction
{
    public interface IEmailService
    {
        void SendEmail(string toAddress, string subject, string body);
    }
}
