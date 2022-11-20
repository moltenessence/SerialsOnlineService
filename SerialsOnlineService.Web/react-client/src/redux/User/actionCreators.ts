import usersService from "../../Services/UsersService";
import tokenStorage from "../../Services/TokenStorage";
import { UserActions } from "./userReducer";
import { AppDispatch } from "../store";
import { setisFetching, setUser } from "./actions";
import { IUpdateUserRequest } from "../../Common/Models/IUser";

export const fetchUser = () => {
    return async (dispatch: AppDispatch<UserActions>) => {
        dispatch(setisFetching(true));
        const email = tokenStorage.getUserDataFromToken()?.email;
        await usersService.getByEmail(email).then((user) => {
            dispatch(setUser(user));
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