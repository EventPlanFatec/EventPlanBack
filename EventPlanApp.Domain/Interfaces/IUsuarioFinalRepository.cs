using EventPlanApp.Domain.Entities;

namespace EventPlanApp.Domain.Interfaces
{
    public interface IUsuarioFinalRepository : IRepository<UsuarioFinal>
    {
        Task<UsuarioFinal> GetByEmailAsync(string email);
        Task<IEnumerable<UsuarioFinal>> GetByNameAsync(string nome);
    }
}
