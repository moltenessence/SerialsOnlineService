namespace SerialsOnlineCenter.ViewModels.Rating
{
    public record RatingViewModel(int Id, int Value, string? Annotation, int UserId, int SerialId);
}
