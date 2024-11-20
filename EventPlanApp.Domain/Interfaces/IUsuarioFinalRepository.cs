using EventPlanApp.Domain.Entities;

namespace EventPlanApp.Domain.Interfaces
{
    public interface IUsuarioFinalRepository : IRepository<UsuarioFinal>
    {
        Task<UsuarioFinal> GetByEmailAsync(string email);
        Task<IEnumerable<UsuarioFinal>> GetByNameAsync(string nome);
        Task<UsuarioFinal> GetByIdAsync(Guid id); // Adicionando o método para buscar usuário pelo ID
        Task UpdateAsync(UsuarioFinal usuarioFinal);
        Task<UsuarioFinal> GetByIdAsync(int id);
    }
}
