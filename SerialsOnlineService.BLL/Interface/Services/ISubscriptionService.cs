using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineService.BLL.Interface.Services
{
    public interface ISubscriptionService : IGenericService<Subscription>
    {
        Task<decimal> GetAveragePrice(CancellationToken cancellationToken);

        Task<Subscription> GetByMinPrice(CancellationToken cancellationToken);

        Task<Subscription> GetByMaxPrice(CancellationToken cancellationToken);
    }
}
