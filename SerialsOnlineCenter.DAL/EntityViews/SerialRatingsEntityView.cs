using SerialsOnlineCenter.DAL.Interfaces;

namespace SerialsOnlineCenter.DAL.EntityViews
{
    public record SerialRatingsEntityView(IReadOnlyList<SerialRating> SerialRatings, decimal Average) : IEntityView;
}
