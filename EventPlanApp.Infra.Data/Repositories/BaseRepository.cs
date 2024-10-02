using Microsoft.EntityFrameworkCore;

namespace EventPlanApp.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        protected readonly EventPlanContext _context;

        protected BaseRepository(EventPlanContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            var entity = await GetById(id);
            if (entity == null)
                return false;

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<TEntity> Update(Guid id, TEntity entity)
        {
            var existingEntity = await GetById(id);
            if (existingEntity == null)
                throw new KeyNotFoundException($"{typeof(TEntity).Name} not found.");

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return existingEntity;
        }
    }
}
