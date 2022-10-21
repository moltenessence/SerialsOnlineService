using SerialsOnlineService.BLL.Interface.Models;

namespace SerialsOnlineService.BLL.Models
{
    public record SerialWithRequiredSubscriptionDTO(string Name,
        string Genre,
        string? Description,
        string RequiredSubscription) : IModel;
}
