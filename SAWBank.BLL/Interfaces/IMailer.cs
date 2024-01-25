using System.Net.Mail;

namespace SAWBank.BLL.Interfaces
{
    public interface IMailer
    {
        void Send(string to, string subject, string html, params Attachment[] attachments);
    }
}
