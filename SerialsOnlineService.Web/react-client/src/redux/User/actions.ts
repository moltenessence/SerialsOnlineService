import { SET_IS_FETCHING, SET_USER } from "./constants";
import {IUser} from "../../Common/Models/IUser";

export type SetUserAction = { type: typeof SET_USER, payload: IUser };
export type SetIsFetchingAction = { type: typeof SET_IS_FETCHING, payload: boolean };

export const setUser = (user: IUser): SetUserAction => ({ type: SET_USER, payload: user });
export const setisFetching = (isFetching: boolean): SetIsFetchingAction => ({ type: SET_IS_FETCHING, payload: isFetching });