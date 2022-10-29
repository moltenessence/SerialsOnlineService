namespace SerialsOnlineCenter.ViewModels.Purchase
{
    public record PostPurchaseViewModel(DateOnly Date,
        int AmountOfMonths,
        int UserId,
        int SubscriptionId,
        decimal TotalPrice);
}
