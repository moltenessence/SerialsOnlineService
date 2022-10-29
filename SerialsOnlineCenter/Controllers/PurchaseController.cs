using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SerialsOnlineCenter.ViewModels.Purchase;
using SerialsOnlineService.BLL.Interface.Services;
using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : GenericController<IPurchaseService, Purchase, PurchaseViewModel>
    {
        public PurchaseController(IPurchaseService service, IMapper mapper) : base(service, mapper) { }


        [HttpGet("maxprice/{amount}")]
        public async Task<IReadOnlyList<PurchaseViewModel>> GetTopPurchasesByMaxTotalPrice(int amount, CancellationToken cancellationToken)
        {
            var purchases = await _service.GetTopPurchasesByMaxTotalPrice(amount, cancellationToken);

            var result = _mapper.Map<IReadOnlyList<PurchaseViewModel>>(purchases);

            return result;
        }

    }
}
