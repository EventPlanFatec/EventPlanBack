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
    public class UsuarioAdmRepository : IUsuarioAdmRepository
    {
        private readonly EventPlanContext _context;

        public UsuarioAdmRepository(EventPlanContext context)
        {
            _context = context;
        }

        public async Task<UsuarioAdm> GetById(int id)
        {
            return await _context.UsuariosAdm.FindAsync(id); // Busca por Guid
        }
    }

}
