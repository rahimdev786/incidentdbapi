using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit.Text;

namespace incidentdbapi;
public class MailService : IMailService
{
    private readonly MailSettings _mailSettings;
    public MailService(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }
    public async Task SendEmailAsync(MailRequest mailRequest)
    {
        // create email message
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
        email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
        // email.Subject = mailRequest.Subject;
        // email.Body = new TextPart(TextFormat.Html) { Text = mailRequest.Body };

        email.Subject = "Incident APP Password reset";
        email.Body = new TextPart(TextFormat.Html) { Text = "<p> please open link for reset password</p> <h3> http://localhost:4200/reset </h3>" };

        // send email
        using var smtp = new SmtpClient();
        smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
        smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
        await smtp.SendAsync(email);
        smtp.Disconnect(true);
    }
}