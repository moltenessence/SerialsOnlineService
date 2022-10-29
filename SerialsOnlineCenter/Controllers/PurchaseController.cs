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

        [HttpPost]
        public async Task<PurchaseViewModel> Add(PostPurchaseViewModel viewModel, CancellationToken cancellationToken)
        {
            var modelToInsert = _mapper.Map<Purchase>(viewModel);

            var result = await _service.Insert(modelToInsert, cancellationToken);

            return _mapper.Map<PurchaseViewModel>(result);
        }

        [HttpPut("{id}")]
        public async Task<PurchaseViewModel> Update(int id, UpdatePurchaseViewModel viewModel, CancellationToken cancellationToken)
        {
            var modelToUpdate = _mapper.Map<Purchase>(viewModel);

            var result = await _service.Update(id, modelToUpdate, cancellationToken);

            return _mapper.Map<PurchaseViewModel>(result);
        }

        [HttpGet("maxprice/{amount}")]
        public async Task<IReadOnlyList<PurchaseViewModel>> GetTopPurchasesByMaxTotalPrice(int amount, CancellationToken cancellationToken)
        {
            var purchases = await _service.GetTopPurchasesByMaxTotalPrice(amount, cancellationToken);

            var result = _mapper.Map<IReadOnlyList<PurchaseViewModel>>(purchases);

            return result;
        }

    }
}
