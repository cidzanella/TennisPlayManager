using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Options;
using TennisRanking.Models;

namespace TennisRanking.Services
{
    /// <summary>
    /// Serviço de envio de email via SendGrid
    /// </summary>
    public class EmailSender : IEmailSender
    {
        
        public EmailSender(IOptions<SendGridAuthentication> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public SendGridAuthentication Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKeyRankingGTM, subject, message, email);
        }

        public Task SendEmailAsync(Email email)
        {
            return Execute(Options.SendGridKeyRankingGTM, email.Subject, email.BodyPlainText, email.ToAdress);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("ranking@gtmtennis.com.br", "Ranking GTM"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}
