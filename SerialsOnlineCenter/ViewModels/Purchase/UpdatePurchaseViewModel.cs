namespace SerialsOnlineCenter.ViewModels.Purchase
{
    public record UpdatePurchaseViewModel(DateOnly Date,
        int AmountOfMonths,
        int UserId,
        int SubscriptionId);
}
