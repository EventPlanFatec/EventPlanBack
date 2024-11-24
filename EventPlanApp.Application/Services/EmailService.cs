using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

public class EmailService : IEmailService
{
    private readonly string _apiKey;
    private string _sendGridApiKey;

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

    public async Task SendEmailWithAttachmentAsync(string to, string subject, string body, byte[] attachment)
    {
        var client = new SendGridClient(_apiKey);
        var from = new EmailAddress("EventPlanFatec@outlook.com", "EventPlan");
        var toEmail = new EmailAddress(to);
        var plainTextContent = body;
        var htmlContent = $"<strong>{body}</strong>";
        var msg = MailHelper.CreateSingleEmail(from, toEmail, subject, plainTextContent, htmlContent);

        // Adicionar anexo
        if (attachment != null)
        {
            string fileBase64 = Convert.ToBase64String(attachment);
            msg.AddAttachment("Ingresso.pdf", fileBase64);
        }

        var response = await client.SendEmailAsync(msg);
        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = $"Erro ao enviar email com anexo: {response.StatusCode}. Detalhes: {await response.Body.ReadAsStringAsync()}";
            throw new Exception(errorMessage);
        }
    }
    public async Task EnviarNotificacaoPrivacidadeAlterada(string email)
    {
        var client = new SendGridClient(_sendGridApiKey);
        var from = new EmailAddress("noreply@seusite.com", "Seu Site");
        var subject = "Mudança na Privacidade do Evento";
        var to = new EmailAddress(email);
        var plainTextContent = "A privacidade do evento foi alterada. Agora é um evento privado.";
        var htmlContent = "<strong>A privacidade do evento foi alterada. Agora é um evento privado.</strong>";
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

        var response = await client.SendEmailAsync(msg);
    }

    public async Task SendEmail(string to, string subject, string body)
    {
        // Implementação para enviar e-mail (usando SMTP ou qualquer outro serviço de e-mail)
        var mailMessage = new MailMessage("admin@seusite.com", to)
        {
            Subject = subject,
            Body = body
        };

        var smtpClient = new SmtpClient("smtp.seusite.com")
        {
            Credentials = new NetworkCredential("usuario", "senha")
        };

        await smtpClient.SendMailAsync(mailMessage);
    }

}
