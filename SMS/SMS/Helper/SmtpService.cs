using MailKit.Net.Smtp; 
using MailKit.Security; 
using MimeKit; 
using Microsoft.Extensions.Configuration;

namespace SMS.Helper
{
    public class SmtpService
    {

        private readonly IConfiguration _configuration;
        public SmtpService(IConfiguration configuration)
        {
             _configuration = configuration;
        }

        public async Task SendEmailAsync(string ToName, string ToEmail,string subject, string body)
        {
           
            string FromName = "BAIUST";
            string FromEmail = "nasirhossain11993@gmail.com";

         


            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress(FromName, FromEmail));
            message.To.Add(new MailboxAddress(ToName, ToEmail));
            message.Subject = subject;

            BodyBuilder builder = new BodyBuilder();
            builder.HtmlBody = body;

            message.Body =builder.ToMessageBody();


            using (SmtpClient client = new SmtpClient())
            {
                var smtp = _configuration.GetSection("SmtpSettings");
                await client.ConnectAsync(smtp["Server"], int.Parse(smtp["Port"], (System.Globalization.NumberStyles)SecureSocketOptions.StartTls));
                await client.AuthenticateAsync(smtp["Username"], smtp["Password"]);
                await client.SendAsync(message);
                await client.DisconnectAsync(true); 
            }
        }
    }
}
