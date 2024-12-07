using AutoMapper;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Interfaces;

namespace EventPlanApp.Application.Services
{
    public abstract class ServiceBase<TDTO, TEntity> : IService<TDTO>
        where TDTO : class
        where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        protected ServiceBase(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<IEnumerable<TDTO>> GetAll()
        {
            var entities = await _repository.GetAll();
            return _mapper.Map<IEnumerable<TDTO>>(entities);
        }

        public virtual async Task<TDTO> GetById(string id)
        {
            var entity = await _repository.GetById(id);
            return _mapper.Map<TDTO>(entity);
        }

        public virtual async Task<TDTO> Add(TDTO dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var addedEntity = await _repository.Add(entity);
            return _mapper.Map<TDTO>(addedEntity);
        }

        public virtual async Task<TDTO> Update(string id, TDTO dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var updatedEntity = await _repository.Update(id, entity);
            return _mapper.Map<TDTO>(updatedEntity);
        }

        public virtual async Task<bool> Delete(string id)
        {
            return await _repository.Delete(id);
        }
    }
}
