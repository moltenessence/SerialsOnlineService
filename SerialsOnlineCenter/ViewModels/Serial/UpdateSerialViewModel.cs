namespace SerialsOnlineCenter.ViewModels.Serial
{
    public record UpdateSerialViewModel(
        string Name,
        int ReleaseYear,
        int AmountOfSeries,
        string? Description,
        string Genre,
        int SubscriptionId);
}
