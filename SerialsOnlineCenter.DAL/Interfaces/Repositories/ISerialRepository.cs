using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.EntityViews;

namespace SerialsOnlineCenter.DAL.Interfaces.Repositories
{
    public interface ISerialRepository
    {
        Task<SerialEntity> GetById(int id, CancellationToken cancellationToken);
        Task<IReadOnlyList<SerialEntity>> GetOrderedByOldestReleaseYear(int id, CancellationToken cancellationToken);
        Task<IReadOnlyList<SerialEntity>> GetOrderedByLatestReleaseYear(int id, CancellationToken cancellationToken);
        Task<IReadOnlyList<SerialEntity>> GetByGenre(string genre, CancellationToken cancellationToken);
        Task<IReadOnlyList<SerialEntity>> GetAccordingToSubscription(int subscriptionId, CancellationToken cancellationToken);
        Task<IReadOnlyList<SerialEntity>> GetTopWithTheMinimalAmountOfSeries(int amountOfSerials, CancellationToken cancellationToken);
        Task<IReadOnlyList<SerialEntity>> GetTopWithTheLargestAmountOfSeries(int amountOfSerials, CancellationToken cancellationToken);
        Task<IReadOnlyList<SerialEntity>> GetAll(CancellationToken cancellationToken);
        Task<SerialEntity> DeleteById(int id, CancellationToken cancellationToken);
        Task<SerialEntity> Insert(SerialEntity entity, CancellationToken cancellationToken);
        Task<SerialEntity> Update(SerialEntity entity, CancellationToken cancellationToken);
        Task<IReadOnlyList<SerialWithRequiredSubscription>> GetWithRequiredSubscription(CancellationToken cancellationToken);
        Task<IReadOnlyList<string>> GetAllGenres(CancellationToken cancellationToken);
    }
}
