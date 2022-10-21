using AutoMapper;
using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.Interfaces.Repositories;
using SerialsOnlineService.BLL.Interface.Services;
using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineService.BLL.Service
{
    public class SerialService : GenericService<Serial, SerialEntity>, ISerialService
    {
        private readonly ISerialRepository _repository;
        private readonly IMapper _mapper;
        public SerialService(ISerialRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public async Task<IReadOnlyList<Serial>> GetOrderedByOldestReleaseYear(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetOrderedByOldestReleaseYear(cancellationToken);

            var result = _mapper.Map<IReadOnlyList<Serial>>(entities);

            return result;
        }

        public async Task<IReadOnlyList<Serial>> GetOrderedByLatestReleaseYear(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetOrderedByLatestReleaseYear(cancellationToken);

            var result = _mapper.Map<IReadOnlyList<Serial>>(entities);

            return result;
        }

        public async Task<IReadOnlyList<Serial>> GetTopWithTheLargestAmountOfSeries(int amountOfSerials, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetTopWithTheLargestAmountOfSeries(amountOfSerials, cancellationToken);

            var result = _mapper.Map<IReadOnlyList<Serial>>(entities);

            return result;
        }

        public async Task<IReadOnlyList<Serial>> GetTopWithTheMinimalAmountOfSeries(int amountOfSerials, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetTopWithTheMinimalAmountOfSeries(amountOfSerials, cancellationToken);

            var result = _mapper.Map<IReadOnlyList<Serial>>(entities);

            return result;
        }

        public async Task<IReadOnlyList<Serial>> GetAccordingToSubscription(int subscriptionId, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAccordingToSubscription(subscriptionId, cancellationToken);

            var result = _mapper.Map<IReadOnlyList<Serial>>(entities);

            return result;
        }

        public async Task<IReadOnlyList<Serial>> GetByGenre(string genre, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByGenre(genre, cancellationToken);

            var result = _mapper.Map<IReadOnlyList<Serial>>(entities);

            return result;
        }


        public async Task<IReadOnlyList<SerialWithRequiredSubscriptionDTO>> GetWithRequiredSubscription(CancellationToken cancellationToken)
        {
            var entityView = await _repository.GetWithRequiredSubscription(cancellationToken);

            var result = _mapper.Map<IReadOnlyList<SerialWithRequiredSubscriptionDTO>>(entityView);

            return result;
        }

        public async Task<IReadOnlyList<SerialsGroupedByGenreDTO>> GetGroupedByGenre(CancellationToken cancellationToken)
        {
            var entityView = await _repository.GetGroupedByGenre(cancellationToken);

            var result = _mapper.Map<IReadOnlyList<SerialsGroupedByGenreDTO>>(entityView);

            return result;
        }

        public async Task<IReadOnlyList<string>> GetAllGenres(CancellationToken cancellationToken)
        {
            return await _repository.GetAllGenres(cancellationToken);
        }
    }
}
