using SerialsOnlineCenter.DAL.Interfaces;

namespace SerialsOnlineCenter.DAL.EntityViews
{
    public record SerialRating(int Value, string Annotation, string UserName) : IEntityView;
}
