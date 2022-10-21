using AutoMapper;
using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.Interfaces.Repositories;
using SerialsOnlineService.BLL.Interface.Services;
using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineService.BLL.Service
{
    public class SubscriptionService : GenericService<Subscription, SubscriptionEntity>, ISubscriptionService
    {
        private readonly ISubscriptionRepository _repository;
        private readonly IMapper _mapper;

        public SubscriptionService(ISubscriptionRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public async Task<decimal> GetAveragePrice(CancellationToken cancellationToken)
        {
            var result = await _repository.GetAveragePrice(cancellationToken);

            return result;
        }

        public async Task<Subscription> GetByMinPrice(CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByMinPrice(cancellationToken);

            var result = _mapper.Map<Subscription>(entity);

            return result;
        }

        public async Task<Subscription> GetByMaxPrice(CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByMaxPrice(cancellationToken);

            var result = _mapper.Map<Subscription>(entity);

            return result;
        }
    }
}
