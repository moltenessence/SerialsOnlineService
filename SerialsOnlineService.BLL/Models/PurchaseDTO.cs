namespace SerialsOnlineService.BLL.Models
{
    public record PurchaseDTO(int Id, int AmountOfMonths, DateOnly Date, decimal TotalPrice, string Subscription);
}
