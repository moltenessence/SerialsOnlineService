import { createSelector } from "reselect";
import { IPurchase } from "../../Common/Models/IPurchase";
import { RootState } from "../store";

const selectPurchases = (state: RootState) => state.purchasesPage.purchases;

const selectIsFetching = (state: RootState) => state.purchasesPage.isFetching;

export const getPurchases = createSelector(selectPurchases, (purchases: Array<IPurchase> | null) => {
    return purchases;
});

export const isFetching = createSelector(selectIsFetching, (isFetching: boolean) => {
    return isFetching;
})