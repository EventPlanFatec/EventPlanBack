using EventPlanApp.Application.Interfaces;
using EventPlanApp.Application.ViewModels;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using EventPlanApp.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    public class AuditService : IAuditService
    {
        private readonly IAuditLogRepository _auditLogRepository;
        private readonly EventPlanContext _context;
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;

        public AuditService(IAuditLogRepository auditLogRepository, EventPlanContext context, IEmailService emailService, IUserRepository userRepository)
        {
            _auditLogRepository = auditLogRepository;
            _context = context;
            _userRepository = userRepository;
            _emailService = emailService;
            _emailService = emailService;
            _userRepository = userRepository;
        }

        public async Task RegistrarAcaoAsync(int usuarioAdmId, string tipoAcao, string descricao, string conteudoAlteradoAntes, string conteudoAlteradoDepois, string ipEndereco)
        {
            var auditLog = new AuditLog
            {
                UsuarioAdmId = usuarioAdmId,
                TipoAcao = tipoAcao,
                Descricao = descricao,
                ConteudoAlteradoAntes = conteudoAlteradoAntes,
                ConteudoAlteradoDepois = conteudoAlteradoDepois,
                DataHora = DateTime.UtcNow,
                IpEndereco = ipEndereco
            };

            await _auditLogRepository.AddAsync(auditLog);
        }

        public async Task RegisterAuditLogAsync(string userId, string actionType, string route, DateTime timestamp)
        {
            var auditLog = new AuditLog
            {
                UserId = userId,
                ActionType = actionType,
                EntityName = route,   // Ou pode ser mais detalhado dependendo do seu modelo de dados
                Date = timestamp
            };

            _context.AuditLogs.Add(auditLog);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AuditLog>> GetAuditLogsAsync(AuditLogFilter filter)
        {
            IQueryable<AuditLog> query = _context.AuditLogs.AsQueryable();

            // Filtro por data (intervalo)
            if (filter.StartDate.HasValue && filter.EndDate.HasValue)
            {
                query = query.Where(log => log.Date >= filter.StartDate && log.Date <= filter.EndDate);
            }

            // Filtro por tipo de ação
            if (!string.IsNullOrEmpty(filter.ActionType))
            {
                query = query.Where(log => log.ActionType.Contains(filter.ActionType));
            }

            // Filtro por usuário
            if (!string.IsNullOrEmpty(filter.UserId))
            {
                query = query.Where(log => log.UserId.Contains(filter.UserId));
            }

            return await query.ToListAsync();
        }

        public async Task MonitorSuspiciousActions(string userId, string actionType, string details)
        {
            if (actionType == "LoginFailed")
            {
                // Verificar tentativas de login falhas
                var failedAttemptsString = await _userRepository.GetFailedLoginAttempts(userId);

                // Converter failedAttempts para inteiro
                if (int.TryParse(failedAttemptsString, out int failedAttempts))
                {
                    if (failedAttempts >= 5)
                    {
                        // Log de auditoria
                        var auditLog = new AuditLog
                        {
                            UserId = userId,
                            ActionType = actionType,
                            Details = "Múltiplas tentativas de login falhas",
                            Date = DateTime.Now
                        };
                        await _auditLogRepository.SaveAuditLog(auditLog);

                        // Enviar alerta para administradores
                        await SendAlertToAdmins($"Múltiplas tentativas de login falhas para o usuário {userId}");

                        // Destacar a ação no log de auditoria
                        auditLog.IsSuspicious = true;
                        await _auditLogRepository.UpdateAuditLog(auditLog);
                    }
                }
                else
                {
                    // Caso a conversão falhe
                    // Aqui você pode adicionar alguma ação caso a conversão para inteiro não seja bem-sucedida
                    Console.WriteLine("Falha ao converter tentativas de login para inteiro");
                }
            }
            else if (actionType == "ConfigChange" && details.Contains("Admin"))
            {
                // Mudança inesperada em configurações sensíveis
                var auditLog = new AuditLog
                {
                    UserId = userId,
                    ActionType = actionType,
                    Details = "Mudança em configurações críticas",
                    Date = DateTime.Now
                };
                await _auditLogRepository.SaveAuditLog(auditLog);

                // Enviar alerta para administradores
                await SendAlertToAdmins($"Mudança crítica de configuração realizada por {userId}");

                // Destacar a ação no log de auditoria
                auditLog.IsSuspicious = true;
                await _auditLogRepository.UpdateAuditLog(auditLog);
            }
        }



        private async Task SendAlertToAdmins(string message)
        {
            // Aqui você implementa o envio de e-mail ou SMS para os administradores.
            var admins = await _userRepository.GetAdmins();
            foreach (var admin in admins)
            {
                await _emailService.SendEmail(admin.Email, "Alerta de Ação Suspeita", message);
            }
        }
    }
}
