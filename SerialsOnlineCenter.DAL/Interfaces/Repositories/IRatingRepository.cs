using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.EntityViews;

namespace SerialsOnlineCenter.DAL.Interfaces.Repositories
{
    public interface IRatingRepository : IGenericRepository<RatingEntity>
    {
        Task<IReadOnlyList<RatingWithUserAndSerialNames>> GetWithUsersAndSerialNames(CancellationToken cancellationToken);
        Task<SerialRatingsEntityView> GetSerialRatings(int serialId, CancellationToken cancellationToken);
    }
}
