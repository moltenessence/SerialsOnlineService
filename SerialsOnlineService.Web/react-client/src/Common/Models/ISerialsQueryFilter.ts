export interface ISerialsQueryFilter {
    name?: string,
    amountOfSeries?: number,
    releaseYear?: number,
    orderByReleaseDesc?: boolean,
    orderByAmountOfSeriesDesc?: boolean
}