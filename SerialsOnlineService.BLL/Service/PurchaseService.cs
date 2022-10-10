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
    }
}
