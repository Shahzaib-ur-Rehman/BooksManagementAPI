using BooksManagementAPI.Models.DTOs;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace BooksManagementAPI.ThirdPartyServices
{
    public class GmailService: IEMailSender
    {
        private readonly EmailConfiguartionDTO _configuration;

        public GmailService(IOptions<EmailConfiguartionDTO> config)
        {
            _configuration = config.Value;
        }

        public Task SendMail(string from , string subject,string to,string body)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(from, subject);
            message.To.Add(to);
            message.Body = body;

            using (var smtpClient = new SmtpClient(_configuration.Host,_configuration.Port))
            {
                smtpClient.Credentials = new NetworkCredential(_configuration.Username, _configuration.Password);
                smtpClient.EnableSsl = true;
                smtpClient.Send(message);
            }

            return Task.CompletedTask;
        }
    }
}
