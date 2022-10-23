namespace SerialsOnlineCenter.ViewModels
{
    public record SerialViewModel(int Id,
        string Name,
        int ReleaseYear,
        int AmountOfSeries,
        string? Description,
        string Genre,
        int SubscriptionId);
}
