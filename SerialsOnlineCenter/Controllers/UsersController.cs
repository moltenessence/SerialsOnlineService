using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SerialsOnlineCenter.ViewModels.User;
using SerialsOnlineService.BLL.Interface.Services;
using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : GenericController<IUserService, User, UserViewModel>
    {
        public UsersController(IUserService service, IMapper mapper) : base(service, mapper)
        {
        }

        [HttpPost]
        public async Task<UserViewModel> Add(PostUserViewModel viewModel, CancellationToken cancellationToken)
        {
            var modelToInsert = _mapper.Map<User>(viewModel);

            var result = await _service.Insert(modelToInsert, cancellationToken);

            return _mapper.Map<UserViewModel>(result);
        }

        [HttpPut("{id}")]
        public async Task<UserViewModel> Update(int id, UpdateUserViewModel viewModel, CancellationToken cancellationToken)
        {
            var modelToUpdate = _mapper.Map<User>(viewModel);

            var result = await _service.Update(id, modelToUpdate, cancellationToken);

            return _mapper.Map<UserViewModel>(result);
        }

        [HttpGet("purchases")]
        public async Task<IReadOnlyList<UserWithPurchasesViewModel>> GetWithPurchases(decimal? minPrice, CancellationToken cancellationToken)
        {
            var result = await _service.GetWithPurchases(minPrice, cancellationToken);

            return _mapper.Map<IReadOnlyList<UserWithPurchasesViewModel>>(result);
        }

    }
}
