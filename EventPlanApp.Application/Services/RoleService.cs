using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using EventPlanApp.Infra.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly EventPlanContext _context;
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository, EventPlanContext context)
        {
            _roleRepository = roleRepository;
            _context = context;
        }

        public async Task CreateRoleAsync(RoleRequest roleRequest)
        {
            // Criando a instância de Role com os valores do roleRequest
            var role = new Role(roleRequest.RoleName, string.Join(",", roleRequest.Permissions));

            // Adicionando o role ao contexto e salvando no banco de dados
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
        }

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

      
    }
}
