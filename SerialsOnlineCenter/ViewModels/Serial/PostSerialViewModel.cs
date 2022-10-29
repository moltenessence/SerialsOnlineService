namespace SerialsOnlineCenter.ViewModels.Serial
{
    public record PostSerialViewModel(
        string Name,
        int ReleaseYear,
        int AmountOfSeries,
        string? Description,
        string Genre,
        int SubscriptionId);
}
