using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineService.BLL.Interface.Services
{
    public interface ISerialService : IGenericService<Serial>
    {
        Task<IReadOnlyList<Serial>> GetOrderedByOldestReleaseYear(CancellationToken cancellationToken);
        Task<IReadOnlyList<Serial>> GetOrderedByLatestReleaseYear(CancellationToken cancellationToken);
        Task<IReadOnlyList<Serial>> GetTopWithTheLargestAmountOfSeries(int amountOfSerials, CancellationToken cancellationToken);
        Task<IReadOnlyList<Serial>> GetTopWithTheMinimalAmountOfSeries(int amountOfSerials, CancellationToken cancellationToken);
        Task<IReadOnlyList<Serial>> GetAccordingToSubscription(int subscriptionId, CancellationToken cancellationToken);
        Task<IReadOnlyList<Serial>> GetByGenre(string genre, CancellationToken cancellationToken);
        Task<IReadOnlyList<SerialWithRequiredSubscriptionDTO>> GetWithRequiredSubscription(CancellationToken cancellationToken);
        Task<IReadOnlyList<SerialsGroupedByGenreDTO>> GetGroupedByGenre(CancellationToken cancellationToken);
        Task<IReadOnlyList<string>> GetAllGenres(CancellationToken cancellationToken);
    }
}
