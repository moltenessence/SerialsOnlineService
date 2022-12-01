import { SET_IS_FETCHING, SET_SUBSCRIPTION, SET_USER } from "./constants";
import {IUser} from "../../Common/Models/IUser";
import { ISubscription } from "../../Common/Models/ISubscription";

export type SetUserAction = { type: typeof SET_USER, payload: IUser };
export type SetIsFetchingAction = { type: typeof SET_IS_FETCHING, payload: boolean };
export type SetSubscriptionAction = { type: typeof SET_SUBSCRIPTION, payload: ISubscription | null };

export const setUser = (user: IUser): SetUserAction => ({ type: SET_USER, payload: user });
export const setisFetching = (isFetching: boolean): SetIsFetchingAction => ({ type: SET_IS_FETCHING, payload: isFetching });
export const setSubscription = (subscription: ISubscription | null): SetSubscriptionAction => ({ type: SET_SUBSCRIPTION, payload: subscription });