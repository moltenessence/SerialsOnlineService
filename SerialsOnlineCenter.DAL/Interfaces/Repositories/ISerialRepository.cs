using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.EntityViews;

namespace SerialsOnlineCenter.DAL.Interfaces.Repositories
{
    public interface ISerialRepository : IGenericRepository<SerialEntity>
    {
        Task<IReadOnlyList<SerialEntity>> GetOrderedByOldestReleaseYear(CancellationToken cancellationToken);
        Task<IReadOnlyList<SerialEntity>> GetOrderedByLatestReleaseYear(CancellationToken cancellationToken);
        Task<IReadOnlyList<SerialEntity>> GetByGenre(string genre, CancellationToken cancellationToken);
        Task<IReadOnlyList<SerialEntity>> GetAccordingToSubscription(int subscriptionId, CancellationToken cancellationToken);
        Task<IReadOnlyList<SerialEntity>> GetTopWithTheMinimalAmountOfSeries(int amountOfSerials, CancellationToken cancellationToken);
        Task<IReadOnlyList<SerialEntity>> GetTopWithTheLargestAmountOfSeries(int amountOfSerials, CancellationToken cancellationToken);
        Task<IReadOnlyList<SerialWithRequiredSubscription>> GetWithRequiredSubscription(CancellationToken cancellationToken);
        Task<IReadOnlyList<string>> GetAllGenres(CancellationToken cancellationToken);
        Task<IReadOnlyList<SerialsGroupedByGenre>> GetGroupedByGenre(CancellationToken cancellationToken);
    }
}
