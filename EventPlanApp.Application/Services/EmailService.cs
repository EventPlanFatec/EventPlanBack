using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

public class EmailService : IEmailService
{
    private readonly string _apiKey;

    public EmailService(string apiKey)
    {

        apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");

    }

    public async Task SendEmailAsync(MensagemEmail mensagemEmail)
    {
        var client = new SendGridClient(_apiKey);
        var from = new EmailAddress("EventPlanFatec@outlook.com", "EventPlan");
        var to = new EmailAddress(mensagemEmail.Destinatario);
        var plainTextContent = mensagemEmail.Conteudo;
        var htmlContent = $"<strong>{mensagemEmail.Conteudo}</strong>";
        var msg = MailHelper.CreateSingleEmail(from, to, mensagemEmail.Assunto, plainTextContent, htmlContent);

        var response = await client.SendEmailAsync(msg);
        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = $"Erro ao enviar email: {response.StatusCode}. Detalhes: {await response.Body.ReadAsStringAsync()}";
            throw new Exception(errorMessage);
        }
    }

}
