using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.EntityViews;

namespace SerialsOnlineCenter.DAL.Interfaces.Repositories
{
    public interface IRatingRepository
    {
        Task<RatingEntity> Insert(int userId, int serialId, RatingEntity entity, CancellationToken cancellationToken);
        Task<double> GetSerialRating(int serialId, CancellationToken cancellationToken);
        Task<IReadOnlyList<RatingWithUserAndSerialNames>> GetAll(CancellationToken cancellationToken);
        Task<RatingEntity> DeleteById(int id, CancellationToken cancellationToken);
        Task<RatingEntity> Update(RatingEntity entity, CancellationToken cancellationToken);
    }
}
