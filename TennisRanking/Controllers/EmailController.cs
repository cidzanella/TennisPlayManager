using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using TennisRanking.Models;

namespace TennisRanking.Controllers
{
    /// <summary>
    /// Controller que realiza envio de email através da api SendGrid
    /// </summary>
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Send(Email email)
        {
            email.ToAdress = "cidzanella@hotmail.com";
            email.ToName = "Cidnelson";
            email.Subject = "Desafio";
            email.BodyPlainText = "Olá Cidnelson! Sua posição no ranking está sendo desafiada por Geferson.";
            email.BodyHtml = "Olá Cidnelson! Sua posição no ranking está sendo desafiada por Geferson.";
            await SendGridExecute(email);

            return View("Index");
        }
        
        private async Task SendGridExecute(Email email)
        {
            var apiKey = Environment.GetEnvironmentVariable("SendGridRankingGTM");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(email.FromAdress, email.FromName);
            var subject = email.Subject;
            var to = new EmailAddress(email.ToAdress, email.ToName);
            var plainTextContent = email.BodyPlainText;
            var htmlContent = email.BodyHtml;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
