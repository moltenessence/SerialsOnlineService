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
        private readonly ISubscriptionRepository _subscriptionRepository;

        public PurchaseService(IPurchaseRepository repository, IMapper mapper, ISubscriptionRepository subscriptionRepository) : base(repository, mapper)
        {
            _repository = repository;
            _subscriptionRepository = subscriptionRepository;
        }

        public override async Task<Purchase> Update(int id, Purchase model, CancellationToken cancellationToken)
        {
            var entityToUpdate = _mapper.Map<PurchaseEntity>(model);
            entityToUpdate.Id = id;

            entityToUpdate.TotalPrice = await CalculateTotalPrice(model, cancellationToken);

            var entity = await _repository.Update(entityToUpdate, cancellationToken);

            var result = _mapper.Map<Purchase>(entity);

            return result;
        }

        public override async Task<Purchase> Insert(Purchase model, CancellationToken cancellationToken)
        {
            var entityToInsert = _mapper.Map<PurchaseEntity>(model);

            entityToInsert.TotalPrice = await CalculateTotalPrice(model, cancellationToken);

            var entity = await _repository.Insert(entityToInsert, cancellationToken);

            var result = _mapper.Map<Purchase>(entity);

            return result;
        }

        public async Task<IReadOnlyList<Purchase>> GetTopPurchasesByMaxTotalPrice(int amountOfPurchases, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetTopPurchasesByMaxTotalPrice(amountOfPurchases, cancellationToken);

            var result = _mapper.Map<IReadOnlyList<Purchase>>(entities);

            return result;
        }

        private async Task<decimal> CalculateTotalPrice(Purchase model, CancellationToken cancellationToken)
        {
            var subscription = await _subscriptionRepository.GetById(model.SubscriptionId, cancellationToken);

            return model.AmountOfMonths * subscription.PricePerMonth;
        }
    }
}
