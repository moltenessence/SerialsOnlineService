using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SerialsOnlineCenter.ViewModels.Login;
using SerialsOnlineService.BLL.Interface.Services;
using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        private readonly IMapper _mapper;

        public AuthController(IAuthService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<bool> Login(LoginViewModel viewModel, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<LoginModel>(viewModel);

            var result = await _service.Login(model, cancellationToken);

            return result;
        }
    }
}
