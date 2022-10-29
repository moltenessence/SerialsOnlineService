namespace SerialsOnlineCenter.ViewModels.Purchase
{
    public record PurchaseViewModel(int Id, DateOnly Date,
        int AmountOfMonths,
        int UserId,
        int SubscriptionId,
        decimal TotalPrice);
}
