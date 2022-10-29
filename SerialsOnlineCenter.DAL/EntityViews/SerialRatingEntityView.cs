namespace SerialsOnlineCenter.DAL.EntityViews
{
    public record SerialRatingEntityView(IReadOnlyList<SerialRating> SerialRatings, decimal Average);
}
