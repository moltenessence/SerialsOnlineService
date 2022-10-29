using SerialsOnlineService.BLL.Interface.Models;

namespace SerialsOnlineService.BLL.Models
{
    public record Subscription(int Id = default, string Name = null, decimal PricePerMonth = default) : IModel;
}
