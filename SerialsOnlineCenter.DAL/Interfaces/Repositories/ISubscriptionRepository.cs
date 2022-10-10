using SerialsOnlineCenter.DAL.Entities;

namespace SerialsOnlineCenter.DAL.Interfaces.Repositories
{
    public interface ISubscriptionRepository : IGenericRepository<SubscriptionEntity>
    {
        Task<SubscriptionEntity> GetByMinPrice(CancellationToken cancellationToken);
        Task<SubscriptionEntity> GetByMaxPrice(CancellationToken cancellationToken);
        Task<decimal> GetAveragePrice(CancellationToken cancellationToken);
    }
}
