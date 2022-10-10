namespace SerialsOnlineCenter.DAL.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : IEntityBase
    {
        Task<TEntity> GetById(int id, CancellationToken cancellationToken);
        Task<IReadOnlyList<TEntity>> GetAll(CancellationToken cancellationToken);
        Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> Insert(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> DeleteById(int id, CancellationToken cancellationToken);
    }
}
