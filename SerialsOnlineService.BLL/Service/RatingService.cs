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

        public async Task<Rating> SetForSerial(int userId, int serialId, Rating entity, CancellationToken cancellationToken)
        {
            var rating = _mapper.Map<RatingEntity>(entity);

            var ratingEntity = await _repository.SetForSerial(userId, serialId, rating, cancellationToken);

            var result = _mapper.Map<Rating>(ratingEntity);

            return result;
        }

        public async Task<double> GetSerialRating(int serialId, CancellationToken cancellationToken)
        {
            var result = await _repository.GetSerialRating(serialId, cancellationToken);

            return result;
        }

        public async Task<IReadOnlyList<RatingWithUserAndSerialNamesDTO>> GetWithUsersAndSerialNames(CancellationToken cancellationToken)
        {
            var entityView = await _repository.GetWithUsersAndSerialNames(cancellationToken);

            var result = _mapper.Map<IReadOnlyList<RatingWithUserAndSerialNamesDTO>>(entityView);

            return result;
        }
    }
}
