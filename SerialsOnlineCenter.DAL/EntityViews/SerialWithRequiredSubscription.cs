using SerialsOnlineCenter.DAL.Interfaces;

namespace SerialsOnlineCenter.DAL.EntityViews
{
    public record SerialWithRequiredSubscription(string Name, string Genre, string? Description, string RequiredSubscription) : IEntityView;
}
