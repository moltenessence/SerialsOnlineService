using AutoMapper;
using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.FilterProperties;
using SerialsOnlineCenter.DAL.Interfaces.Repositories;
using SerialsOnlineService.BLL.Exceptions;
using SerialsOnlineService.BLL.Filter;
using SerialsOnlineService.BLL.Interface.Services;
using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineService.BLL.Service
{
    public class SerialService : GenericService<Serial, SerialEntity>, ISerialService
    {
        private readonly ISerialRepository _serialRepository;

        private readonly IRatingRepository _ratingRepository;

        public SerialService(ISerialRepository repository, IRatingRepository ratingRepository, IMapper mapper) : base(repository, mapper)
        {
            _serialRepository = repository;
            _ratingRepository = ratingRepository;
        }

        public async Task<IReadOnlyList<Serial>> GetAccordingToSubscription(int subscriptionId, CancellationToken cancellationToken)
        {
            var entities = await _serialRepository.GetAccordingToSubscription(subscriptionId, cancellationToken);

            var result = _mapper.Map<IReadOnlyList<Serial>>(entities);

            return result;
        }

        public async Task<IReadOnlyList<Serial>> GetByFilter(SerialsFilter filter, CancellationToken cancellationToken)
        {
            if (!CheckIfFilterIsValid(filter))
                throw new InvalidFilterParametersException("You can't get data sorted by asc and desc simultaneously.");

            var properties = _mapper.Map<SerialFilterProperties>(filter);
            var entities = await _serialRepository.GetByFilterProperties(properties, cancellationToken);

            var result = _mapper.Map<IReadOnlyList<Serial>>(entities);

            return result;
        }

        public async Task<SerialWithRatings> GetWithRatings(int serialId, CancellationToken cancellationToken)
        {
            var serialEntity = await _serialRepository.GetById(serialId, cancellationToken);
            var ratingEntities = await _ratingRepository.GetSerialRatings(serialId, cancellationToken);

            var serial = _mapper.Map<Serial>(serialEntity);
            var ratings = _mapper.Map<SerialRatingsDTO>(ratingEntities);

            var result = new SerialWithRatings(serial, ratings);

            return result;
        }


        public async Task<IReadOnlyList<SerialWithRequiredSubscriptionDTO>> GetWithRequiredSubscription(CancellationToken cancellationToken)
        {
            var entityView = await _serialRepository.GetWithRequiredSubscription(cancellationToken);

            var result = _mapper.Map<IReadOnlyList<SerialWithRequiredSubscriptionDTO>>(entityView);

            return result;
        }

        public async Task<IReadOnlyList<SerialsGroupedByGenreDTO>> GetGroupedByGenre(CancellationToken cancellationToken)
        {
            var entityView = await _serialRepository.GetGroupedByGenre(cancellationToken);

            var result = _mapper.Map<IReadOnlyList<SerialsGroupedByGenreDTO>>(entityView);

            return result;
        }

        public async Task<IReadOnlyList<string>> GetAllGenres(CancellationToken cancellationToken)
        {
            return await _serialRepository.GetAllGenres(cancellationToken);
        }

        public async Task<IReadOnlyList<Serial>> GetAvailableForUser(int userId, CancellationToken cancellationToken)
        {
            var entities = await _serialRepository.GetAvailableForUser(userId, cancellationToken);

            var result = _mapper.Map<IReadOnlyList<Serial>>(entities);

            return result;
        }

        private bool CheckIfFilterIsValid(SerialsFilter filter)
        {
            if (filter is null || true == filter?.AmountOfSeries < 0)
            {
                return false;
            }

            return true;
        }
    }
}
