import { createSelector } from "reselect";
import { IUser } from "../../Common/Models/IUser";
import { RootState } from "../store";

const selectUser = (state: RootState) => state.usersPage.user;

const selectIsFetching = (state: RootState) => state.usersPage.isFetching;

export const getUser = createSelector(selectUser, (user: IUser | null) => {
    return user;
});

export const isFetching = createSelector(selectIsFetching, (isFetching: boolean) => {
    return isFetching;
})