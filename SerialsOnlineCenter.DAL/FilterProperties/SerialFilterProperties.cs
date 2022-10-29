using SerialsOnlineCenter.DAL.Interfaces.FilterProperties;

namespace SerialsOnlineCenter.DAL.FilterProperties
{
    public record SerialFilterProperties(
        string? Name = null,
        int? AmountOfSeries = null,
        int? ReleaseYear = null,
        bool? OrderByReleaseDesc = false,
        bool? OderByAmountOfSeriesDesc = false) : IFilterProperties;
}
