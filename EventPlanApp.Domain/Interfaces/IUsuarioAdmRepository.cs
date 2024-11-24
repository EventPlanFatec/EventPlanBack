using EventPlanApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Interfaces
{
    public interface IUsuarioAdmRepository
    {
        Task<UsuarioAdm> GetById(int id);
        Task<UsuarioAdm> GetByIdAsync(int id);
        Task<IEnumerable<UsuarioAdm>> GetAllAsync();
        Task AddAsync(UsuarioAdm usuarioAdm);
        Task UpdateAsync(UsuarioAdm usuarioAdm);
        Task DeleteAsync(int id);
    }
}
