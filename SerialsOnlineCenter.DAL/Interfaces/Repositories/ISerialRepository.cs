using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.EntityViews;
using SerialsOnlineCenter.DAL.FilterProperties;

namespace SerialsOnlineCenter.DAL.Interfaces.Repositories
{
    public interface ISerialRepository : IGenericRepository<SerialEntity>
    {
        Task<IReadOnlyList<SerialEntity>> GetAccordingToSubscription(int subscriptionId, CancellationToken cancellationToken);
        Task<IReadOnlyList<SerialWithRequiredSubscription>> GetWithRequiredSubscription(CancellationToken cancellationToken);
        Task<IReadOnlyList<string>> GetAllGenres(CancellationToken cancellationToken);
        Task<IReadOnlyList<SerialsGroupedByGenre>> GetGroupedByGenre(CancellationToken cancellationToken);
        Task<IReadOnlyList<SerialEntity>> GetByFilterProperties(SerialFilterProperties? props, CancellationToken cancellationToken);
        Task<IReadOnlyList<SerialEntity>> GetAvailableForUser(int userId, CancellationToken cancellationToken);
    }
}
