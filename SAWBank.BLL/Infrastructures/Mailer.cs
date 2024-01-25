using SAWBank.BLL.Interfaces;
using System.Net;
using System.Net.Mail;

namespace SAWBank.BLL.Infrastructures
{
    public class Mailer(SmtpClient _smtpClient, Mailer.MailerConfig _config) : IMailer
    {
        public class MailerConfig
        {
            public required string Server { get; init; }
            public required int Port { get; init; }
            public required string Username { get; init; }
            public required string Password { get; init; }
        }

        public void Send(
            string to, string subject, string html, params Attachment[] attachments
        )
        {
            _smtpClient.Host = _config.Server;
            _smtpClient.Port = _config.Port;
            _smtpClient.Credentials = new NetworkCredential
                (_config.Username, _config.Password);
            _smtpClient.EnableSsl = true;


            MailMessage mailMessage = new MailMessage();
            mailMessage.Subject = subject;
            mailMessage.Body = html;
            mailMessage.IsBodyHtml = true;
            mailMessage.From = new MailAddress("noreply@sawbank.com");
            mailMessage.To.Add(to);
            foreach (var item in attachments)
            {
                mailMessage.Attachments.Add(item);
            }
            _smtpClient.Send(mailMessage);
        }
    }
}
