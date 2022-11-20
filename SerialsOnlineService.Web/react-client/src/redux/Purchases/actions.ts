import { SET_IS_FETCHING, SET_PURCHASES } from "./constants";
import { IPurchase } from "../../Common/Models/IPurchase";

export type SetPurchasesAction = { type: typeof SET_PURCHASES, payload: Array<IPurchase> | null};
export type SetIsFetchingAction = { type: typeof SET_IS_FETCHING, payload: boolean };

export const setPurchases = (purchase: Array<IPurchase> ): SetPurchasesAction => ({ type: SET_PURCHASES, payload: purchase });
export const setisFetching = (isFetching: boolean): SetIsFetchingAction => ({ type: SET_IS_FETCHING, payload: isFetching });