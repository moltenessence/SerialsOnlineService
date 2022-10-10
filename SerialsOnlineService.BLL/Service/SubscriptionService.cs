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
    }
}
