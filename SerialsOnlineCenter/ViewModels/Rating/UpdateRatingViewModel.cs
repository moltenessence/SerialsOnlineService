namespace SerialsOnlineCenter.ViewModels.Rating
{
    public record UpdateRatingViewModel(int Value, string? Annotation, int UserId, int SerialId);
}
