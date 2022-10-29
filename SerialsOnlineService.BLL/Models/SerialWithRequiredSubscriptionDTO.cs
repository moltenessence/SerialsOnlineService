using SerialsOnlineService.BLL.Interface.Models;

namespace SerialsOnlineService.BLL.Models
{
    public record SerialWithRequiredSubscriptionDTO(string Name, string? Description, string Genre, string RequiredSubscription) : IModel;
}
