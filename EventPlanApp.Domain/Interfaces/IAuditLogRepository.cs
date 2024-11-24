using EventPlanApp.Domain.Entities;
using EventPlanApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Interfaces
{
    public interface IAuditLogRepository
    {
        Task AddAsync(AuditLog auditLog);
        Task SaveAuditLog(AuditLog log);
        Task UpdateAuditLog(AuditLog log);
        Task<IEnumerable<AuditLog>> GetAuditLogs(AuditLogFilter filter);
    }
}
