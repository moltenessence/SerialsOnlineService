
import { createSelector } from "reselect";
import { ISubscription } from "../../Common/Models/ISubscription";
import { RootState } from "../store";

const selectSubscriptions = (state: RootState) => state.subscriptionsPage.subscriptions;

const selectIsFetching = (state: RootState) => state.subscriptionsPage.isFetching;

export const getSubscriptions  = createSelector(selectSubscriptions, (subscriptions: Array<ISubscription>) => {
    return subscriptions;
});

export const getIsFetching = createSelector(selectIsFetching, (isFetching: boolean) => {
    return isFetching;
})