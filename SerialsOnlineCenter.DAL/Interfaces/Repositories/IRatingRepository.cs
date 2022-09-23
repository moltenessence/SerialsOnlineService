using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.EntityViews;

namespace SerialsOnlineCenter.DAL.Interfaces.Repositories
{
    public interface IRatingRepository
    {
        Task<RatingEntity> SetRating(int userId, int serialId, RatingEntity entity, CancellationToken cancellationToken);
        Task<double> CalculateSerialRating(int serialId, CancellationToken cancellationToken);
        Task<IReadOnlyList<RatingWithUserAndSerialNames>> GetAllRatings(CancellationToken cancellationToken);
    }
}
