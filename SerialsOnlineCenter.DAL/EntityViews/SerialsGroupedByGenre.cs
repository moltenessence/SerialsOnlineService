using SerialsOnlineCenter.DAL.Interfaces;

namespace SerialsOnlineCenter.DAL.EntityViews
{
    public record SerialsGroupedByGenre(string Genre, long Amount) : IEntityView;
}
