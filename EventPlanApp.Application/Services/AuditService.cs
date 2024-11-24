using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using EventPlanApp.Infra.Data;
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

        public AuditService(IAuditLogRepository auditLogRepository, EventPlanContext context)
        {
            _auditLogRepository = auditLogRepository;
            _context = context;
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
    }
}
