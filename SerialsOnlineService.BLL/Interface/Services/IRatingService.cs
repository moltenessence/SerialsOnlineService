using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineService.BLL.Interface.Services
{
    public interface IRatingService : IGenericService<Rating>
    {
        Task<Rating> SetForSerial(int userId, int serialId, Rating entity, CancellationToken cancellationToken);
        Task<double> GetSerialRating(int serialId, CancellationToken cancellationToken);
        Task<IReadOnlyList<RatingWithUserAndSerialNamesDTO>> GetWithUsersAndSerialNames(CancellationToken cancellationToken);
    }
}
