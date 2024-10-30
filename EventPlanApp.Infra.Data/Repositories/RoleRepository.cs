using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Infra.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly EventPlanContext _context;

        public RoleRepository(EventPlanContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }
    }
}
