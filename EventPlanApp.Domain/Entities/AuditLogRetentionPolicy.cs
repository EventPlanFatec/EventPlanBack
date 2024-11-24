using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class AuditLogRetentionPolicy
    {
        public int RetentionPeriodInDays { get; set; }  // Período de retenção em dias
        public bool ArchiveOldLogs { get; set; }  // Se os logs antigos devem ser arquivados ou excluídos
        public string ArchiveLocation { get; set; }  // Local onde os logs arquivados serão armazenados
    }
}
