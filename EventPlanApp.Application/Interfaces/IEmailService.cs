using EventPlanApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(MensagemEmail mensagemEmail);

        Task SendEmailWithAttachmentAsync(string to, string subject, string body, byte[] attachment);

    }
}
