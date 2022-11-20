
import { createSelector } from "reselect";
import { ISerial } from "../../Common/Models/ISerial";
import { RootState } from "../store";

const selectSerials = (state: RootState) => state.serialsPage.serials;

const selectModalContent = (state: RootState) => state.serialsPage.modalContent;

const selectIsFetching = (state: RootState) => state.serialsPage.isFetching;

export const getSerials = createSelector(selectSerials, (serials: Array<ISerial>) => {
    return serials;
});


export const getModalContent = createSelector(selectModalContent, (modalContent: ISerial | null) => {
    return modalContent;
});

export const getIsFetching = createSelector(selectIsFetching, (isFetching: boolean) => {
    return isFetching;
})