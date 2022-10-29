using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SerialsOnlineCenter.ViewModels.Subscription;
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

        [HttpGet("price/max")]
        public async Task<SubscriptionViewModel> GetByMaxPrice(CancellationToken cancellationToken)
        {
            var subscriptions = await _service.GetByMaxPrice(cancellationToken);

            var result = _mapper.Map<SubscriptionViewModel>(subscriptions);

            return result;
        }

        [HttpGet("price/min")]
        public async Task<SubscriptionViewModel> GetByMinPrice(CancellationToken cancellationToken)
        {
            var subscriptions = await _service.GetByMinPrice(cancellationToken);

            var result = _mapper.Map<SubscriptionViewModel>(subscriptions);

            return result;
        }

        [HttpGet("price/avg")]
        public async Task<decimal> GetByAveragePrice(CancellationToken cancellationToken)
        {
            var result = await _service.GetAveragePrice(cancellationToken);

            return result;
        }
    }
}
