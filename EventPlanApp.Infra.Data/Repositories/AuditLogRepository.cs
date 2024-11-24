using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Infra.Data.Repositories
{
    public class AuditLogRepository : IAuditLogRepository
    {
        private readonly EventPlanContext _context;

        public AuditLogRepository(EventPlanContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AuditLog auditLog)
        {
            await _context.AuditLogs.AddAsync(auditLog);
            await _context.SaveChangesAsync();
        }
    }

}
