using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using EventPlanApp.Infra.Data;
using Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    public class AuditLogRetentionService
    {
        private readonly EventPlanContext _context;
        private readonly IAuditLogRepository _auditLogRepository;

        public AuditLogRetentionService(EventPlanContext context, IAuditLogRepository auditLogRepository)
        {
            _context = context;
            _auditLogRepository = auditLogRepository;
        }

        public async Task ApplyRetentionPolicy(AuditLogRetentionPolicy policy)
        {
            var retentionDate = DateTime.Now.AddDays(-policy.RetentionPeriodInDays);
            var oldLogs = _context.AuditLogs.Where(log => log.Date < retentionDate);

            foreach (var log in oldLogs)
            {
                if (policy.ArchiveOldLogs)
                {
                    // Arquivamento do log (por exemplo, movendo para outro local)
                    await ArchiveLog(log, policy.ArchiveLocation);
                }
                else
                {
                    // Exclusão do log
                    _context.AuditLogs.Remove(log);
                }
            }

            await _context.SaveChangesAsync();
        }

        private async Task ArchiveLog(AuditLog log, string archiveLocation)
        {
            // Implementar a lógica de arquivamento, por exemplo, salvar em uma pasta ou banco de dados separado
            // Aqui, só como exemplo, estamos apenas registrando no console
            Console.WriteLine($"Arquivo arquivado em: {archiveLocation} - Log: {log.Id}");
            await Task.CompletedTask;
        }
    }
}
