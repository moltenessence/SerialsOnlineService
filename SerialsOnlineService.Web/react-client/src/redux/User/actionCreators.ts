import usersService from "../../Services/UsersService";
import tokenStorage from "../../Services/TokenStorage";
import { UserActions } from "./userReducer";
import { AppDispatch } from "../store";
import { setisFetching, setSubscription, setUser } from "./actions";
import { IUpdateUserRequest } from "../../Common/Models/IUser";
import subscriptionsService from "../../Services/SubscriptionsService";

export const fetchUser = () => {
    return async (dispatch: AppDispatch<UserActions>) => {
        dispatch(setisFetching(true));
        const email = tokenStorage.getUserDataFromToken()?.email;
        await usersService.getByEmail(email).then((user) => {
            dispatch(setUser(user));
            subscriptionsService.getById(user.subscriptionId as number).then((subscription) => {
                dispatch(setSubscription(subscription));
            });

            dispatch(setisFetching(false));
        });
    };
};

export const updateUser = (user: IUpdateUserRequest) => {
    return async (dispatch: AppDispatch<UserActions>) => {
        await usersService.update(user).then((user) => {
            fetchUser();
        });
    };
};