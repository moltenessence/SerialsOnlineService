using AutoMapper;
using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.Interfaces.Repositories;
using SerialsOnlineService.BLL.Interface.Services;
using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineService.BLL.Service
{
    public class UserService : GenericService<User, UserEntity>, IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<UserWithPurchasesDTO>> GetWithPurchases(decimal? minPrice, CancellationToken cancellationToken)
        {
            if (minPrice is null) minPrice = 0;

            var entities = await _repository.GetWithPurchases(minPrice, cancellationToken);

            var result = _mapper.Map<IReadOnlyList<UserWithPurchasesDTO>>(entities);

            return result;
        }
    }
}
