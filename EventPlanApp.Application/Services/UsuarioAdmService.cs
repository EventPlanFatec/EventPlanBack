using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    public class UsuarioAdmService : IUsuarioAdmService
    {
        private readonly IUsuarioAdmRepository _usuarioAdmRepository;

        public UsuarioAdmService(IUsuarioAdmRepository usuarioAdmRepository)
        {
            _usuarioAdmRepository = usuarioAdmRepository;
        }

        public async Task<UsuarioAdm> ObterPorIdAsync(int id)
        {
            return await _usuarioAdmRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<UsuarioAdm>> ObterTodosAsync()
        {
            return await _usuarioAdmRepository.GetAllAsync();
        }

        public async Task CriarUsuarioAdmAsync(UsuarioAdm usuarioAdm)
        {
            await _usuarioAdmRepository.AddAsync(usuarioAdm);
        }

        public async Task AtualizarUsuarioAdmAsync(UsuarioAdm usuarioAdm)
        {
            await _usuarioAdmRepository.UpdateAsync(usuarioAdm);
        }

        public async Task ExcluirUsuarioAdmAsync(int id)
        {
            await _usuarioAdmRepository.DeleteAsync(id);
        }
    }
}
