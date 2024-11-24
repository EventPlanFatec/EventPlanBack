using EventPlanApp.Application.ViewModels;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using Google;
using Microsoft.EntityFrameworkCore;
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

        public async Task SaveAuditLog(AuditLog auditLog)
        {
            if (auditLog == null)
                throw new ArgumentNullException(nameof(auditLog));

            await _context.AuditLogs.AddAsync(auditLog);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAuditLog(AuditLog auditLog)
        {
            if (auditLog == null)
                throw new ArgumentNullException(nameof(auditLog));

            _context.AuditLogs.Update(auditLog);
            await _context.SaveChangesAsync();
        }

        // Implementando o método GetAuditLogs com filtro
        public async Task<IEnumerable<AuditLog>> GetAuditLogs(AuditLogFilter filter)
        {
            var query = _context.AuditLogs.AsQueryable();

            if (filter.StartDate.HasValue)
            {
                query = query.Where(log => log.Date >= filter.StartDate.Value);
            }

            if (filter.EndDate.HasValue)
            {
                query = query.Where(log => log.Date <= filter.EndDate.Value);
            }

            if (!string.IsNullOrEmpty(filter.ActionType))
            {
                query = query.Where(log => log.ActionType == filter.ActionType);
            }

            if (!string.IsNullOrEmpty(filter.UserId))
            {
                query = query.Where(log => log.UserId == filter.UserId);
            }

            return await query.ToListAsync();
        }
    }

}
