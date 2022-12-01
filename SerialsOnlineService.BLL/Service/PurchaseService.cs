using AutoMapper;
using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.Interfaces.Repositories;
using SerialsOnlineService.BLL.Exceptions;
using SerialsOnlineService.BLL.Interface.Services;
using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineService.BLL.Service
{
    public class PurchaseService : GenericService<Purchase, PurchaseEntity>, IPurchaseService
    {
        private readonly IPurchaseRepository _repository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUserRepository _userRepository;

        public PurchaseService(IPurchaseRepository repository,
            IMapper mapper,
            ISubscriptionRepository subscriptionRepository,
            IUserRepository userRepository) : base(repository, mapper)
        {
            _repository = repository;
            _subscriptionRepository = subscriptionRepository;
            _userRepository = userRepository;
        }

        public override async Task<Purchase> Update(int id, Purchase model, CancellationToken cancellationToken)
        {
            if (!await CheckIfEntityExists(id, cancellationToken)) throw new ModelNotFoundException(id);

            var entityToUpdate = _mapper.Map<PurchaseEntity>(model);
            entityToUpdate.Id = id;

            entityToUpdate.TotalPrice = await CalculateTotalPrice(model, cancellationToken);

            var entity = await _repository.Update(entityToUpdate, cancellationToken);

            var result = _mapper.Map<Purchase>(entity);

            return result;
        }

        public override async Task<Purchase> Insert(Purchase model, CancellationToken cancellationToken)
        {
            var relatedUser = await _userRepository.GetById(model.UserId, cancellationToken);

            if (relatedUser.SubscriptionId == model.SubscriptionId)
            {
                throw new DomainException("User already has this type of subcription.");
            }

            var entityToInsert = _mapper.Map<PurchaseEntity>(model);

            entityToInsert.TotalPrice = await CalculateTotalPrice(model, cancellationToken);
            entityToInsert.Date = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

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

        public async Task<IReadOnlyList<PurchaseDTO>> GetByUserId(int userId, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByUserId(userId, cancellationToken);

            var result = _mapper.Map<IReadOnlyList<PurchaseDTO>>(entities);
            return result;
        }

        private async Task<decimal> CalculateTotalPrice(Purchase model, CancellationToken cancellationToken)
        {
            var subscription = await _subscriptionRepository.GetById(model.SubscriptionId, cancellationToken);

            return model.AmountOfMonths * subscription.PricePerMonth;
        }


    }
}
