using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.EntityViews;

namespace SerialsOnlineCenter.DAL.Interfaces.Repositories
{
    public interface IPurchaseRepository : IGenericRepository<PurchaseEntity>
    {
        Task<IReadOnlyList<PurchaseEntity>> GetTopPurchasesByMaxTotalPrice(int amountOfPurchases, CancellationToken cancellationToken);
        Task<IReadOnlyList<PurchaseEntityView>> GetByUserId(int userId, CancellationToken cancellationToken);
    }
}
