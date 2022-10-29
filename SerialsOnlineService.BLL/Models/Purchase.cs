using SerialsOnlineService.BLL.Interface.Models;

namespace SerialsOnlineService.BLL.Models
{
    public record Purchase(int Id = default,
        DateOnly Date = default,
        int AmountOfMonths = default,
        int UserId = default,
        int SubscriptionId = default,
        decimal TotalPrice = default) : IModel;
}
