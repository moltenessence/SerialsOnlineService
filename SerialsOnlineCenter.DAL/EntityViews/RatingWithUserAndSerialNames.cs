using SerialsOnlineCenter.DAL.Interfaces;

namespace SerialsOnlineCenter.DAL.EntityViews
{
    public record RatingWithUserAndSerialNames(int Value, string Annotation, string UserName, string SerialName) : IEntityView;
}
