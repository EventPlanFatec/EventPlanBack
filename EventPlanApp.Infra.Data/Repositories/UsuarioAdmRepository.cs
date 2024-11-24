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
        public async Task<UsuarioAdm> GetByIdAsync(int id)
        {
            return await _context.UsuariosAdm.FindAsync(id);
        }

        public async Task<IEnumerable<UsuarioAdm>> GetAllAsync()
        {
            return await _context.UsuariosAdm.ToListAsync();
        }

        public async Task AddAsync(UsuarioAdm usuarioAdm)
        {
            _context.UsuariosAdm.Add(usuarioAdm);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UsuarioAdm usuarioAdm)
        {
            _context.UsuariosAdm.Update(usuarioAdm);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuarioAdm = await GetByIdAsync(id);
            if (usuarioAdm != null)
            {
                _context.UsuariosAdm.Remove(usuarioAdm);
                await _context.SaveChangesAsync();
            }
        }
    }

}
