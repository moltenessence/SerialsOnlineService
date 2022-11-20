
import { SET_IS_FETCHING, SET_SUBSCRIPTIONS } from "./constants";
import { ISubscription } from "../../Common/Models/ISubscription";

export type SetSubscriptionsAction = { type: typeof SET_SUBSCRIPTIONS, payload: Array<ISubscription> };
export type SetIsFetchingAction = { type: typeof SET_IS_FETCHING, payload: boolean };

export const setSubscriptions = (serials: Array<ISubscription>): SetSubscriptionsAction => ({ type: SET_SUBSCRIPTIONS, payload: serials });
export const setisFetching = (isFetching: boolean): SetIsFetchingAction => ({ type: SET_IS_FETCHING, payload: isFetching });