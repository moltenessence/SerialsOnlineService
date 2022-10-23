using SerialsOnlineService.BLL.Interface.Models;

namespace SerialsOnlineService.BLL.Models
{
    public record Purchase(int Id,
        DateOnly Date,
        int AmountOfMonths,
        int UserId,
        int SubscriptionId,
        decimal TotalPrice) : IModel;
}
