namespace SerialsOnlineService.BLL.Filter
{
    public record SerialsFilter(
        string? Name = null,
        int? AmountOfSeries = null,
        int? ReleaseYear = null,
        bool? OrderByReleaseDesc = false,
        bool? OderByAmountOfSeriesDesc = false);
}
