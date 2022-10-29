using SerialsOnlineCenter.DAL.EntityViews;

namespace SerialsOnlineCenter.ViewModels.Rating
{
    public record SerialRatingViewModel(IReadOnlyList<SerialRating> SerialRatings, decimal Average);
}
