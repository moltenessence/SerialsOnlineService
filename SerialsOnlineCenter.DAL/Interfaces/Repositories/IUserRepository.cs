using SerialsOnlineCenter.DAL.Entities;

namespace SerialsOnlineCenter.DAL.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> GetById(int id, CancellationToken cancellationToken);
        Task<IReadOnlyList<UserEntity>> GetAll(CancellationToken cancellationToken);
        Task<UserEntity> DeleteById(int id, CancellationToken cancellationToken);
        Task<UserEntity> Insert(UserEntity entity, CancellationToken cancellationToken);
        Task<UserEntity> Update(UserEntity entity, CancellationToken cancellationToken);
    }
}
