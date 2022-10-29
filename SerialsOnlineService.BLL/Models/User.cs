using SerialsOnlineService.BLL.Interface.Models;

namespace SerialsOnlineService.BLL.Models
{
    public record User(int Id = default,
        string UserName = null,
        string Email = null,
        int? Age = default,
        int SubscriptionId = default) : IModel;
}
