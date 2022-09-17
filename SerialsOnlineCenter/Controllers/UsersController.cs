using Microsoft.AspNetCore.Mvc;
using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.Interfaces.Repositories;

namespace SerialsOnlineCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        public UsersController(IUserRepository userRepository, IPurchaseRepository purchaseRepository)
        {
            _userRepository = userRepository;
            _purchaseRepository = purchaseRepository;
        }

        [HttpGet]
        public async Task<IReadOnlyList<UserEntity>> GetAll(CancellationToken cancellationToken)
        {
            return await _userRepository.GetAll(cancellationToken);
        }

        [HttpPost]
        public async Task<UserEntity> Add(UserEntity user, CancellationToken cancellationToken)
        {
            return await _userRepository.Insert(user, cancellationToken);
        }

        [HttpPost("purchase")]
        public async Task<PurchaseEntity> Add(PurchaseEntity entity, CancellationToken cancellationToken)
        {
            return await _purchaseRepository.Insert(entity, cancellationToken);
        }
    }
}
