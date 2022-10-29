using SerialsOnlineService.BLL.Interface.Models;

namespace SerialsOnlineService.BLL.Models
{
    public record Serial(int Id = default,
        string Name = null,
        int ReleaseYear = default,
        int AmountOfSeries = default,
        string? Description = null,
        string Genre = null,
        int SubscriptionId = default) : IModel;
}
