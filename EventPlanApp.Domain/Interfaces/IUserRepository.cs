using EventPlanApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<UsuarioFinal> GetByIdAsync(Guid id);
        Task UpdateAsync(UsuarioFinal usuarioFinal);
        Task<IEnumerable<UsuarioFinal>> GetAdmins();
        Task<string> GetFailedLoginAttempts(string userId);
        Task DeactivateUserAsync(Guid userId);
        Task DeleteUserAsync(Guid userId);

    }
}
