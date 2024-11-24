using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
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

        public AuditService(IAuditLogRepository auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
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
    }
}
