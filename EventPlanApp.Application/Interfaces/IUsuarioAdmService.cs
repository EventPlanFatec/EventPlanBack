using EventPlanApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Interfaces
{
    public interface IUsuarioAdmService
    {
        Task<UsuarioAdm> ObterPorIdAsync(int id);
        Task<IEnumerable<UsuarioAdm>> ObterTodosAsync();
        Task CriarUsuarioAdmAsync(UsuarioAdm usuarioAdm);
        Task AtualizarUsuarioAdmAsync(UsuarioAdm usuarioAdm);
        Task ExcluirUsuarioAdmAsync(int id);
    }
}
