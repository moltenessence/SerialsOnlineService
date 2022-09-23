using SerialsOnlineCenter.DAL.Interfaces;

namespace SerialsOnlineCenter.DAL.EntityViews
{
    public record RatingWithUserAndSerialNames(int Value, string UserName, string SerialName, string? Description) : IEntityView;
}
