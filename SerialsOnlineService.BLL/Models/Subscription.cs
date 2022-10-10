using SerialsOnlineService.BLL.Interface.Models;

namespace SerialsOnlineService.BLL.Models
{
    public record Subscription(int Id, string Name, decimal PricePerMonth) : IModel;
}
