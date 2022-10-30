using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineService.BLL.Interface.Services
{
    public interface IUserService : IGenericService<User>
    {
        Task<IReadOnlyList<UserWithPurchasesDTO>> GetWithPurchases(decimal? minPrice,
            CancellationToken cancellationToken);
    }
}
