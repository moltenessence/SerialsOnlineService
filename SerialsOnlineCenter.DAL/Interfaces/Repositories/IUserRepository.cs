using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.EntityViews;

namespace SerialsOnlineCenter.DAL.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        Task<IReadOnlyList<UserWithPurchasesEntityView>> GetWithPurchases(decimal? minPrice,
            CancellationToken cancellationToken);

        Task<UserEntity> GetByEmail(string email, CancellationToken cancellationToken);
    }
}
