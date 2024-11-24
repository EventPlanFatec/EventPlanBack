using System;

namespace EventPlanApp.Application.ViewModels
{
    public class AuditLogFilter
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ActionType { get; set; }  // Ex: "criação", "edição", etc.
        public string UserId { get; set; }      // ID do usuário
    }
}
