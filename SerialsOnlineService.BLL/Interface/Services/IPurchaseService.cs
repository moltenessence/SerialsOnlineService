using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineService.BLL.Interface.Services
{
    public interface IPurchaseService : IGenericService<Purchase>
    {
        Task<IReadOnlyList<Purchase>> GetTopPurchasesByMaxTotalPrice(int amountOfPurchases, CancellationToken cancellationToken);
        Task<IReadOnlyList<PurchaseDTO>> GetByUserId(int userId, CancellationToken cancellationToken);
    }
}
