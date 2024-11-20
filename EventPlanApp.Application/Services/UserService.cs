using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using EventPlanApp.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    public class UserService
    {
        private readonly IUsuarioAdmRepository _usuarioAdmRepository;
        private readonly IUsuarioFinalRepository _usuarioFinalRepository;
        private readonly EventPlanContext _context;

        public UserService(IUsuarioAdmRepository usuarioAdmRepository, IUsuarioFinalRepository usuarioFinalRepository, EventPlanContext context)
        {
            _usuarioAdmRepository = usuarioAdmRepository;
            _usuarioFinalRepository = usuarioFinalRepository;
            _context = context;
        }

        public async Task<bool> UserHasPermission(int userId, string permission)
        {
            var usuarioAdm = await _usuarioAdmRepository.GetById(userId);  // Passando 'int' como ID
            if (usuarioAdm != null && usuarioAdm.Role != null)
            {
                return usuarioAdm.Role.HasPermission(permission);  // Verificando permissão
            }

            var usuarioFinal = await _usuarioFinalRepository.GetById(userId);  // Passando 'int' como ID
            if (usuarioFinal != null && usuarioFinal.Role != null)
            {
                return usuarioFinal.Role.HasPermission(permission);  // Verificando permissão
            }

            return false;
        }

        public async Task<UsuarioAdm> GetById(int id)
        {
            return await _context.UsuariosAdm
                                 .Include(u => u.Role)  // Incluindo o relacionamento com Role
                                 .FirstOrDefaultAsync(u => u.AdmId == id); // Aqui, usando o Guid para buscar o UsuarioAdm
        }
    }

}
