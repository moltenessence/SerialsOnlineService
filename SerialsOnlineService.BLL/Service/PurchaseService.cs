using AutoMapper;
using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.Interfaces.Repositories;
using SerialsOnlineService.BLL.Interface.Services;
using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineService.BLL.Service
{
    public class PurchaseService : GenericService<Purchase, PurchaseEntity>, IPurchaseService
    {
        private readonly IPurchaseRepository _repository;
        private readonly IMapper _mapper;

        public PurchaseService(IPurchaseRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public async Task<IReadOnlyList<Purchase>> GetTopPurchasesByMaxTotalPrice(int amountOfPurchases, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetTopPurchasesByMaxTotalPrice(amountOfPurchases, cancellationToken);

            var result = _mapper.Map<IReadOnlyList<Purchase>>(entities);

            return result;
        }
    }
}
