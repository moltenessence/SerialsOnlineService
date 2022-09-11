using SerialsOnlineCenter.DAL.Entities;

namespace SerialsOnlineCenter.DAL.Interfaces.Repositories
{
    public interface IPurchaseRepository
    {
        Task<PurchaseEntity> GetById(int id, CancellationToken cancellationToken);
        Task<IReadOnlyList<PurchaseEntity>> GetAll(CancellationToken cancellationToken);
        Task<PurchaseEntity> DeleteById(int id, CancellationToken cancellationToken);
        Task<PurchaseEntity> Insert(PurchaseEntity entity, CancellationToken cancellationToken);
        Task<IReadOnlyList<PurchaseEntity>> GetTopPurchasesByMaxTotalPrice(int amountOfPurchases, CancellationToken cancellationToken);
    }
}
