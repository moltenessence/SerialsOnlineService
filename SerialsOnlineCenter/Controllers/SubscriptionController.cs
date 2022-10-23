using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SerialsOnlineCenter.ViewModels;
using SerialsOnlineService.BLL.Interface.Services;
using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : GenericController<ISubscriptionService, Subscription, SubscriptionViewModel>
    {
        private readonly ISubscriptionService _service;
        private readonly IMapper _mapper;

        public SubscriptionController(ISubscriptionService service, IMapper mapper) : base(service, mapper)
        {
            _service = service;
        }
    }
}
