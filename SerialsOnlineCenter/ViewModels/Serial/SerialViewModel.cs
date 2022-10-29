namespace SerialsOnlineCenter.ViewModels.Serial
{
    public record SerialViewModel(int Id,
        string Name,
        int ReleaseYear,
        int AmountOfSeries,
        string? Description,
        string Genre,
        int SubscriptionId);
}
