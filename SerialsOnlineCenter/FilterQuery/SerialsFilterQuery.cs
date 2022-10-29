namespace SerialsOnlineCenter.FilterQuery
{
    public record SerialsFilterQuery(
        string? Name,
        int? AmountOfSeries,
        int? ReleaseYear,
        bool OrderByReleaseDesc = false,
        bool OderByAmountOfSeriesDesc = false);
}
