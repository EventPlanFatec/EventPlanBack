﻿using EventPlanApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Interfaces
{
    public interface IAuditLogRetentionService
    {
        Task ApplyRetentionPolicy(AuditLogRetentionPolicy policy);
    }
}