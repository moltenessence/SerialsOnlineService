using SerialsOnlineCenter.DAL.Interfaces;

namespace SerialsOnlineCenter.DAL.EntityViews
{
    public record SerialWithRequiredSubscription(string Name, string? Description, string Genre, string RequiredSubscription) : IEntityView;
}
