﻿using EventPlanApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task AddAsync(Role role);
        Task<bool> RoleExistsAsync(Guid roleId);

    }
}
