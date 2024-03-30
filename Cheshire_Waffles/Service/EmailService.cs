using System.Net;
using System.Net.Mail;
using Cheshire_Waffles.Service.Abstraction;

namespace Cheshire_Waffles.Service
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;
        private readonly string _fromAddress;

        public EmailService(IConfiguration configuration)
        {
            _smtpServer = configuration["EmailSettings:SmtpServer"] ?? throw new ArgumentNullException();
            _smtpPort = configuration.GetValue<int>("EmailSettings:SmtpPort");
            _smtpUsername = configuration["EmailSettings:SmtpUsername"] ?? throw new ArgumentNullException();
            _smtpPassword = configuration["EmailSettings:SmtpPassword"] ?? throw new ArgumentNullException();
        }

        public void SendEmail(string toAddress, string subject, string body)
        {
            try
            {
                using (var mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(_smtpUsername);
                    mailMessage.To.Add(toAddress);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;

                    using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort))
                    {
                        smtpClient.EnableSsl = true;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
                        smtpClient.Send(mailMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
