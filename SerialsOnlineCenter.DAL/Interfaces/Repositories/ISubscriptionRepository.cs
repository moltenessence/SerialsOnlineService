using SerialsOnlineCenter.DAL.Entities;

namespace SerialsOnlineCenter.DAL.Interfaces.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<SubscriptionEntity> GetById(int id, CancellationToken cancellationToken);
        Task<IReadOnlyList<SubscriptionEntity>> GetAll(CancellationToken cancellationToken);
        Task<SubscriptionEntity> GetByMinPrice(CancellationToken cancellationToken);
        Task<SubscriptionEntity> GetByMaxPrice(CancellationToken cancellationToken);
        Task<decimal> GetAverageSubscriptionPrice(CancellationToken cancellationToken);
        Task<SubscriptionEntity> Update(SubscriptionEntity entity, CancellationToken cancellationToken);
        Task<SubscriptionEntity> Insert(SubscriptionEntity entity, CancellationToken cancellationToken);
        Task<SubscriptionEntity> DeleteById(int id, CancellationToken cancellationToken);
    }
}
