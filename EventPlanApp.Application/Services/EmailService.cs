using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

public class EmailService
{
    private readonly string apiKey;

    public EmailService()
    {
        apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");

        if (string.IsNullOrEmpty(apiKey))
        {
            throw new Exception("SendGrid API Key não foi configurada corretamente.");
        }
    }

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("EventPlanFatec@outlook.com", "EventPlan");
        var to = new EmailAddress(toEmail);
        var plainTextContent = message;
        var htmlContent = $"<strong>{message}</strong>";
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

        var response = await client.SendEmailAsync(msg);
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception("Erro ao enviar email.");
        }
    }
}
