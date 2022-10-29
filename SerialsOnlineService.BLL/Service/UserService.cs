using AutoMapper;
using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.Interfaces.Repositories;
using SerialsOnlineService.BLL.Interface.Services;
using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineService.BLL.Service
{
    public class UserService : GenericService<User, UserEntity>, IUserService
    {
        public UserService(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
