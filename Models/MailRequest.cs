namespace incidentdbapi;
using System.Threading.Tasks;

public class MailRequest
{
    public string? ToEmail { get; set; }
    // public string? Subject { get; set; }
    // public string? Body { get; set; }
}


public interface IMailService
{
    Task SendEmailAsync(MailRequest mailRequest);

}