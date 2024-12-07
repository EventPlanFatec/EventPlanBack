using System.Linq.Expressions;

namespace EventPlanApp.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task<T> Add(T entity);
        Task<T> Update(string id, T entity);
        Task<bool> Delete(string id);
    }
}
