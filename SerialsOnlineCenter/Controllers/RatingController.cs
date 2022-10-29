using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SerialsOnlineCenter.ViewModels.Rating;
using SerialsOnlineService.BLL.Interface.Services;
using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : GenericController<IRatingService, Rating, RatingViewModel>
    {
        public RatingController(IRatingService service, IMapper mapper) : base(service, mapper)
        {
        }

        [HttpPost]
        public async Task<RatingViewModel> Add(PostRatingViewModel viewModel, CancellationToken cancellationToken)
        {
            var modelToInsert = _mapper.Map<Rating>(viewModel);

            var result = await _service.Insert(modelToInsert, cancellationToken);

            return _mapper.Map<RatingViewModel>(result);
        }

        [HttpPut("{id}")]
        public async Task<RatingViewModel> Update(int id, UpdateRatingViewModel viewModel, CancellationToken cancellationToken)
        {
            var modelToUpdate = _mapper.Map<Rating>(viewModel);

            var result = await _service.Update(id, modelToUpdate, cancellationToken);

            return _mapper.Map<RatingViewModel>(result);
        }

        [HttpGet]
        public async Task<IReadOnlyList<RatingWithUserAndSerialNamesViewModel>> GetRatingsWithUserAndSerialNames(CancellationToken cancellationToken)
        {
            var rating = await _service.GetWithUsersAndSerialNames(cancellationToken);

            var result = _mapper.Map<IReadOnlyList<RatingWithUserAndSerialNamesViewModel>>(rating);

            return result;
        }

        [HttpGet("serial/{serialId}")]
        public async Task<SerialRatingViewModel> GetSerialRatings(int serialId, CancellationToken cancellationToken)
        {
            var ratings = await _service.GetSerialRatings(serialId, cancellationToken);

            var result = _mapper.Map<SerialRatingViewModel>(ratings);

            return result;
        }
    }
}
