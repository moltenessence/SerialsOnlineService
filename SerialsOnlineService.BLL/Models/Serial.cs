using SerialsOnlineService.BLL.Interface.Models;

namespace SerialsOnlineService.BLL.Models
{
    public record Serial(string Name,
        int ReleaseYear,
        int AmountOfSeries,
        string? Description,
        string Genre,
        int SubscriptionId) : IModel;
}
