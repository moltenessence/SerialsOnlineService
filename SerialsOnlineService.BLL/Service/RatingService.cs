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

        public RatingService(IRatingRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<RatingWithUserAndSerialNamesDTO>> GetWithUsersAndSerialNames(CancellationToken cancellationToken)
        {
            var entityView = await _repository.GetWithUsersAndSerialNames(cancellationToken);

            var result = _mapper.Map<IReadOnlyList<RatingWithUserAndSerialNamesDTO>>(entityView);

            return result;
        }

        public async Task<SerialRatingDTO> GetSerialRatings(int serialId, CancellationToken cancellationToken)
        {
            var entityView = await _repository.GetSerialRatings(serialId, cancellationToken);

            var result = _mapper.Map<SerialRatingDTO>(entityView);

            return result;
        }
    }
}
