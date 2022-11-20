namespace SerialsOnlineCenter.ViewModels.Purchase
{
    public record UserPurchaseViewModel(int Id, int AmountOfMonths, DateOnly Date, decimal TotalPrice, string Subscription);
}
