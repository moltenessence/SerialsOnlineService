
import { createSelector } from "reselect";
import { ISerial } from "../../Common/Models/ISerial";
import { RootState } from "../store";
import { ISerialWithRatings } from "../../Common/Models/ISerialWithRatings";
import { IRating } from "../../Common/Models/IRating";
import { IGroupedGenres } from "../../Common/Models/IGropedGenres";

const selectSerials = (state: RootState) => state.serialsPage.serials;

const selectModalContent = (state: RootState) => state.serialsPage.modalContent;

const selectIsFetching = (state: RootState) => state.serialsPage.isFetching;

const selectRatings = (state: RootState) => state.serialsPage.ratings;

const selectGenres = (state: RootState) => state.serialsPage.genres;

export const getSerials = createSelector(selectSerials, (serials: Array<ISerial>) => {
    return serials;
});

export const getModalContent = createSelector(selectModalContent, (modalContent: ISerialWithRatings | null) => {
    return modalContent;
});

export const getRatings = createSelector(selectRatings, (ratings: Array<IRating> | null) => {
    return ratings;
});

export const getIsFetching = createSelector(selectIsFetching, (isFetching: boolean) => {
    return isFetching;
});

export const getGenres = createSelector(selectGenres, (genres: Array<IGroupedGenres>) => {
    return genres;
})