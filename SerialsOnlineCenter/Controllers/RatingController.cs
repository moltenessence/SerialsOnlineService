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

        [HttpGet("serial/{serialId}")]
        public async Task<double> GetSerialRating(int serialId, CancellationToken cancellationToken)
        {
            var result = await _service.GetSerialRating(serialId, cancellationToken);

            return result;
        }

        [HttpPost("serial")]
        public async Task<RatingViewModel> SetRatingForSerial(SetRatingViewModel viewModel, CancellationToken cancellationToken)
        {
            var ratingToSet = _mapper.Map<Rating>(viewModel.Rating);

            var rating = await _service.SetForSerial(viewModel.UserId, viewModel.SerialId, ratingToSet, cancellationToken);

            var result = _mapper.Map<RatingViewModel>(rating);

            return result;
        }

        [HttpGet("serials")]
        public async Task<IReadOnlyList<RatingWithUserAndSerialNamesViewModel>> GetRatingsWithUserAndSerialNames(CancellationToken cancellationToken)
        {
            var rating = await _service.GetWithUsersAndSerialNames(cancellationToken);

            var result = _mapper.Map<IReadOnlyList<RatingWithUserAndSerialNamesViewModel>>(rating);

            return result;
        }
    }
}
