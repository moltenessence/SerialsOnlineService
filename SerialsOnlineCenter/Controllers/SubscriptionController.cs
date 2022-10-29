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
        public SubscriptionController(ISubscriptionService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
