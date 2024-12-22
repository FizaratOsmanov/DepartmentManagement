using DepartmentApp.BL.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace DepartmentApp.BL.Services.Implementations
{
    public class EmailService:IEmailService
    {

        IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public void SendWelcome(string toUser)
        {
            SmtpClient smtp = new SmtpClient(_configuration["Email:Host"], Convert.ToInt32(_configuration["Email:Port"]));
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(_configuration["Email:Login"], _configuration["Email:Passcode"]);

            MailAddress from = new MailAddress("fizaratzo-ab205@code.edu.az");
            MailAddress to = new MailAddress(toUser);

            MailMessage message = new MailMessage(from, to);


            message.Subject = "Hello from Fizaret";
            message.Body = "Welcome";
            smtp.Send(message);
        }

        public void SendConfirmEmail(string toUser, string confirmUrl)
        {
            SmtpClient smtp = new SmtpClient(_configuration["Email:Host"], Convert.ToInt32(_configuration["Email:Port"]));
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(_configuration["Email:Login"], _configuration["Email:Passcode"]);

            MailAddress from = new MailAddress("narmin.shivakhanova@code.edu.az");
            MailAddress to = new MailAddress(toUser);

            MailMessage message = new MailMessage(from, to);


            message.Subject = "Confirm Email";
            message.IsBodyHtml = true;
            smtp.Send(message);

        }
    }
}
