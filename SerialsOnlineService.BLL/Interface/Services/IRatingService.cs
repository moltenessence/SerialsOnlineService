using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineService.BLL.Interface.Services
{
    public interface IRatingService : IGenericService<Rating>
    {
        Task<IReadOnlyList<RatingWithUserAndSerialNamesDTO>> GetWithUsersAndSerialNames(CancellationToken cancellationToken);
        Task<SerialRatingsDTO> GetSerialRatings(int serialId, CancellationToken cancellationToken);
    }
}
