﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Interfaces
{
    public interface IAuditLogService
    {
        Task RegisterAuditLogAsync(string userId, string actionType, string route, DateTime timestamp);
    }
}
