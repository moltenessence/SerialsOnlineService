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
        private readonly ISerialRepository _repository;

        public SerialService(ISerialRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<Serial>> GetAccordingToSubscription(int subscriptionId, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAccordingToSubscription(subscriptionId, cancellationToken);

            var result = _mapper.Map<IReadOnlyList<Serial>>(entities);

            return result;
        }

        public async Task<IReadOnlyList<Serial>> GetByFilter(SerialsFilter filter, CancellationToken cancellationToken)
        {
            if (!CheckIfFilterIsValid(filter))
                throw new InvalidFilterParametersException("You can't get data sorted by asc and desc simultaneously.");

            var properties = _mapper.Map<SerialFilterProperties>(filter);
            var entities = await _repository.GetByFilterProperties(properties, cancellationToken);

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
