using System.Threading.Tasks;
using RecipesAPI.Options;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace RecipesAPI.Services
{
    public class EmailService
    {
        private readonly EmailClientOptions emailOptions;

        public EmailService(IOptions<EmailClientOptions> emailOptions)
        {
            this.emailOptions = emailOptions.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Recipes", "no-reply@recipes.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = message };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(emailOptions.Url, emailOptions.Port).ConfigureAwait(false);
                client.Authenticate(emailOptions.Username, emailOptions.Password);
                await client.SendAsync(emailMessage).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
    }

}
