using SerialsOnlineCenter.DAL.EntityViews;

namespace SerialsOnlineCenter.ViewModels.Rating
{
    public record SerialRatingsViewModel(IReadOnlyList<SerialRating> SerialRatings, decimal Average);
}
