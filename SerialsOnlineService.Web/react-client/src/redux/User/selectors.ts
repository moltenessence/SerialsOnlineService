import { createSelector } from "reselect";
import { ISubscription } from "../../Common/Models/ISubscription";
import { IUser } from "../../Common/Models/IUser";
import { RootState } from "../store";

const selectUser = (state: RootState) => state.usersPage.user;

const selectIsFetching = (state: RootState) => state.usersPage.isFetching;

const selectSubscription = (state: RootState) => state.usersPage.subscription;

export const getUser = createSelector(selectUser, (user: IUser | null) => {
    return user;
});

export const getSubscription = createSelector(selectSubscription, (subscription: ISubscription | null) => {
    return subscription;
});

export const isFetching = createSelector(selectIsFetching, (isFetching: boolean) => {
    return isFetching;
})