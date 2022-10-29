using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SerialsOnlineCenter.ViewModels.Serial;
using SerialsOnlineService.BLL.Interface.Services;
using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerialController : GenericController<ISerialService, Serial, SerialViewModel>
    {
        public SerialController(ISerialService service, IMapper mapper) : base(service, mapper)
        {
        }

        [HttpPost]
        public async Task<SerialViewModel> Add(PostSerialViewModel viewModel, CancellationToken cancellationToken)
        {
            var modelToInsert = _mapper.Map<Serial>(viewModel);

            var result = await _service.Insert(modelToInsert, cancellationToken);

            return _mapper.Map<SerialViewModel>(result);
        }

        [HttpPut("{id}")]
        public async Task<SerialViewModel> Update(int id, UpdateSerialViewModel viewModel, CancellationToken cancellationToken)
        {
            var modelToUpdate = _mapper.Map<Serial>(viewModel);

            var result = await _service.Update(id, modelToUpdate, cancellationToken);

            return _mapper.Map<SerialViewModel>(result);
        }

        [HttpGet("minSeries/{amountOfSerials}")]
        public async Task<IReadOnlyList<SerialViewModel>> GetOrderedByMinimalAmountOfSeries(int amountOfSerials, CancellationToken cancellationToken)
        {
            var serials = await _service.GetTopWithTheMinimalAmountOfSeries(amountOfSerials, cancellationToken);

            var result = _mapper.Map<IReadOnlyList<SerialViewModel>>(serials);

            return result;
        }

        [HttpGet("maxSeries/{amountOfSerials}")]
        public async Task<IReadOnlyList<SerialViewModel>> GetOrderedByLargestAmountOfSeries(int amountOfSerials, CancellationToken cancellationToken)
        {
            var serials = await _service.GetTopWithTheLargestAmountOfSeries(amountOfSerials, cancellationToken);

            var result = _mapper.Map<IReadOnlyList<SerialViewModel>>(serials);

            return result;
        }

        [HttpGet("latestRelease")]
        public async Task<IReadOnlyList<SerialViewModel>> GetOrderedByLatestReleaseYear(CancellationToken cancellationToken)
        {
            var serials = await _service.GetOrderedByLatestReleaseYear(cancellationToken);

            var result = _mapper.Map<IReadOnlyList<SerialViewModel>>(serials);

            return result;
        }

        [HttpGet("oldestRelease")]
        public async Task<IReadOnlyList<SerialViewModel>> GetOrderedByOldestReleaseYear(CancellationToken cancellationToken)
        {
            var serials = await _service.GetOrderedByOldestReleaseYear(cancellationToken);

            var result = _mapper.Map<IReadOnlyList<SerialViewModel>>(serials);

            return result;
        }

        [HttpGet("subscription/{subscriptionId}")]
        public async Task<IReadOnlyList<SerialViewModel>> GetBySubscriptionId(int subscriptionId, CancellationToken cancellationToken)
        {
            var serials = await _service.GetAccordingToSubscription(subscriptionId, cancellationToken);

            var result = _mapper.Map<IReadOnlyList<SerialViewModel>>(serials);

            return result;
        }

        [HttpGet("subscriptions")]
        public async Task<IReadOnlyList<SerialWithRequiredSubscriptionViewModel>> GetWithRequiredSubscription(CancellationToken cancellationToken)
        {
            var serials = await _service.GetWithRequiredSubscription(cancellationToken);

            var result = _mapper.Map<IReadOnlyList<SerialWithRequiredSubscriptionViewModel>>(serials);

            return result;
        }

        [HttpGet("byGenres")]
        public async Task<IReadOnlyList<SerialsGroupedByGenreViewModel>> GetGroupedByGenres(CancellationToken cancellationToken)
        {
            var serials = await _service.GetGroupedByGenre(cancellationToken);

            var result = _mapper.Map<IReadOnlyList<SerialsGroupedByGenreViewModel>>(serials);

            return result;
        }

        [HttpGet("genres")]
        public async Task<IReadOnlyList<string>> GetAllByGenres(CancellationToken cancellationToken)
        {
            var result = await _service.GetAllGenres(cancellationToken);

            return result;
        }

    }
}
