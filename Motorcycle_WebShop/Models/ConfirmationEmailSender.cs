using Azure.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Security.Policy;

namespace Motorcycle_WebShop.Models
{
    public class ConfirmationEmailSender
    {
        private readonly IConfiguration _configuration;

        public ConfirmationEmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendConfirmationEmail(string recipientEmail, string confirmationLink)
        {
            string senderEmail = _configuration["EmailSettings:EmailSender"];
            string senderPassword = _configuration["EmailSettings:EmailPassword"];
            string smtpHost = _configuration["EmailSettings:SmtpHost"];
            int smtpPort = _configuration.GetValue<int>("EmailSettings:SmtpPort");

            using (SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtpClient.EnableSsl = true;

                MailMessage mail = new MailMessage(senderEmail, recipientEmail)
                {
                    Subject = "Confirmation Email Motorcycle Webshop",
                    Body = "Please confirm your email by clicking on this link >"+confirmationLink+"< this will redirect you back to our page.",
                    IsBodyHtml = true
                };

                try
                {
                    smtpClient.Send(mail);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
