using AutoMapper;
using SerialsOnlineCenter.DAL.Interfaces;
using SerialsOnlineCenter.DAL.Interfaces.Repositories;
using SerialsOnlineService.BLL.Exceptions;
using SerialsOnlineService.BLL.Interface.Models;
using SerialsOnlineService.BLL.Interface.Services;

namespace SerialsOnlineService.BLL.Service
{
    public class GenericService<TModel, TEntity> : IGenericService<TModel> where TEntity : IEntityBase
                                                                             where TModel : IModel
    {
        protected readonly IMapper _mapper;
        protected readonly IGenericRepository<TEntity> _repository;

        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _mapper = mapper ?? throw new NullReferenceException();
            _repository = repository ?? throw new NullReferenceException();
        }

        public virtual async Task<TModel> Delete(int id, CancellationToken cancellationToken)
        {
            if (!await CheckIfEntityExists(id, cancellationToken)) throw new ModelNotFoundException(id);

            var entity = await _repository.DeleteById(id, cancellationToken);

            var result = _mapper.Map<TModel>(entity);

            return result;
        }

        public virtual async Task<IReadOnlyList<TModel>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAll(cancellationToken);

            var result = _mapper.Map<IReadOnlyList<TModel>>(entities);

            return result;
        }

        public virtual async Task<TModel> GetById(int id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetById(id, cancellationToken);

            var result = _mapper.Map<TModel>(entity);

            return result;
        }

        public virtual async Task<TModel> Insert(TModel model, CancellationToken cancellationToken)
        {
            var entityToInsert = _mapper.Map<TEntity>(model);
            var entity = await _repository.Insert(entityToInsert, cancellationToken);

            var result = _mapper.Map<TModel>(entity);

            return result;
        }

        public virtual async Task<TModel> Update(int id, TModel model, CancellationToken cancellationToken)
        {
            if (!await CheckIfEntityExists(id, cancellationToken)) throw new ModelNotFoundException(id);

            var entityToUpdate = _mapper.Map<TEntity>(model);
            entityToUpdate.Id = id;
            var entity = await _repository.Update(entityToUpdate, cancellationToken);

            var result = _mapper.Map<TModel>(entity);

            return result;
        }

        protected async Task<bool> CheckIfEntityExists(int id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetById(id, cancellationToken);

            if (entity is null) return false;

            return true;
        }
    }
}
