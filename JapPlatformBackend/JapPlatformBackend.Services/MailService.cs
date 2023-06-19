using JapPlatformBackend.Api.Exceptions;
using JapPlatformBackend.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace JapPlatformBackend.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration configuration;

        public MailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<bool> SendEmail(string toEmail, string subject, string content)
        {
            var apiKey = configuration["SendGrid:Key"];
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new JapPlatformException("Invalid Sendgrid Mail Service properties: Key");
            }

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(configuration["SendGrid:FromEmail"]);
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new JapPlatformException("Invalid Sendgrid Mail Service properties: Email");
            }

            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            var response = await client.SendEmailAsync(msg);

            return response.IsSuccessStatusCode;
        }
    }
}
