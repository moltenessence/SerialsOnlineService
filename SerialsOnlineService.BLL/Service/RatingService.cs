using AutoMapper;
using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.Interfaces.Repositories;
using SerialsOnlineService.BLL.Interface.Services;
using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineService.BLL.Service
{
    public class RatingService : GenericService<Rating, RatingEntity>, IRatingService
    {
        private readonly IRatingRepository _repository;
        private readonly IMapper _mapper;
        public RatingService(IRatingRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
