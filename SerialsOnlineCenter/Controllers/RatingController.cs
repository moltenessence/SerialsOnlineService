using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SerialsOnlineCenter.ViewModels;
using SerialsOnlineService.BLL.Interface.Services;
using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : GenericController<IRatingService, Rating, RatingViewModel>
    {
        private readonly IRatingService _service;
        private readonly IMapper _mapper;

        public RatingController(IRatingService service, IMapper mapper) : base(service, mapper)
        {
            _service = service;
        }
    }
}
