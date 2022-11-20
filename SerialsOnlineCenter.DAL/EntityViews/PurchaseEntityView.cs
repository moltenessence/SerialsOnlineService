namespace SerialsOnlineCenter.DAL.EntityViews
{
    public record PurchaseEntityView(int Id, int AmountOfMonths, DateOnly Date, decimal TotalPrice, string Subscription);
}
