using SerialsOnlineCenter.DAL.Entities;

namespace SerialsOnlineCenter.DAL.Interfaces.Repositories
{
    public interface IGenreRepository
    {
        Task<GenreEntity> GetById(int id, CancellationToken cancellationToken);
        Task<IReadOnlyList<GenreEntity>> GetAll(CancellationToken cancellationToken);
    }
}
