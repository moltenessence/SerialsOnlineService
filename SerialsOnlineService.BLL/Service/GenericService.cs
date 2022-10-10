using AutoMapper;
using SerialsOnlineCenter.DAL.Interfaces;
using SerialsOnlineCenter.DAL.Interfaces.Repositories;
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

        public async Task<TModel> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _repository.DeleteById(id, cancellationToken);

            var result = _mapper.Map<TModel>(entity);

            return result;
        }

        public async Task<IReadOnlyList<TModel>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAll(cancellationToken);

            var result = _mapper.Map<IReadOnlyList<TModel>>(entities);

            return result;
        }

        public async Task<TModel> GetById(int id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetById(id, cancellationToken);

            var result = _mapper.Map<TModel>(entity);

            return result;
        }

        public async Task<TModel> Insert(TModel model, CancellationToken cancellationToken)
        {
            var entityToInsert = _mapper.Map<TEntity>(model);
            var entity = await _repository.Insert(entityToInsert, cancellationToken);

            var result = _mapper.Map<TModel>(entity);

            return result;
        }

        public async Task<TModel> Update(TModel model, CancellationToken cancellationToken)
        {
            var entityToUpdate = _mapper.Map<TEntity>(model);
            var entity = await _repository.Update(entityToUpdate, cancellationToken);

            var result = _mapper.Map<TModel>(entity);

            return result;
        }
    }
}
