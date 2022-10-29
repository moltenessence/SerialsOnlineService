using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.EntityViews;

namespace SerialsOnlineCenter.DAL.Interfaces.Repositories
{
    public interface IRatingRepository : IGenericRepository<RatingEntity>
    {
        Task<RatingEntity> SetForSerial(int userId, int serialId, int ratingId, CancellationToken cancellationToken);
        Task<double> GetSerialRating(int serialId, CancellationToken cancellationToken);
        Task<IReadOnlyList<RatingWithUserAndSerialNames>> GetWithUsersAndSerialNames(CancellationToken cancellationToken);
    }
}
