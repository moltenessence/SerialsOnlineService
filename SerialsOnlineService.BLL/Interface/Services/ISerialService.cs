using SerialsOnlineService.BLL.Filter;
using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineService.BLL.Interface.Services
{
    public interface ISerialService : IGenericService<Serial>
    {
        Task<IReadOnlyList<Serial>> GetAccordingToSubscription(int subscriptionId, CancellationToken cancellationToken);
        Task<IReadOnlyList<SerialWithRequiredSubscriptionDTO>> GetWithRequiredSubscription(CancellationToken cancellationToken);
        Task<IReadOnlyList<SerialsGroupedByGenreDTO>> GetGroupedByGenre(CancellationToken cancellationToken);
        Task<IReadOnlyList<string>> GetAllGenres(CancellationToken cancellationToken);
        Task<IReadOnlyList<Serial>> GetByFilter(SerialsFilter filter, CancellationToken cancellationToken);
        Task<IReadOnlyList<Serial>> GetAvailableForUser(int userId, CancellationToken cancellationToken);
    }
}
