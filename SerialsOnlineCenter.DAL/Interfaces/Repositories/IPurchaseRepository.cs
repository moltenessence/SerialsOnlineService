using SerialsOnlineCenter.DAL.Entities;

namespace SerialsOnlineCenter.DAL.Interfaces.Repositories
{
    public interface IPurchaseRepository : IGenericRepository<PurchaseEntity>
    {
        Task<IReadOnlyList<PurchaseEntity>> GetTopPurchasesByMaxTotalPrice(int amountOfPurchases, CancellationToken cancellationToken);
    }
}
