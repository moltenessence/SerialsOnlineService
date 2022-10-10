using SerialsOnlineService.BLL.Interface.Models;

namespace SerialsOnlineService.BLL.Models
{
    public record User(int Id,
        string UserName,
        string Email,
        int? Age,
        int SubscriptionId) : IModel;
}
