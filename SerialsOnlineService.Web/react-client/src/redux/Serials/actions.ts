import { SET_IS_FETCHING, SET_SERIALS, SET_SERIAL, SET_RATINGS, FILTER_SERIALS } from "./constants";
import { ISerial } from "../../Common/Models/ISerial";
import { ISerialWithRatings } from "../../Common/Models/ISerialWithRatings";
import { IRating } from "../../Common/Models/IRating";

export type SetSerialsAction = { type: typeof SET_SERIALS, payload: Array<ISerial> };
export type SetIsFetchingAction = { type: typeof SET_IS_FETCHING, payload: boolean };
export type SetModalContentAction = { type: typeof SET_SERIAL, payload: ISerialWithRatings | null };
export type SetRatingsAction = { type: typeof SET_RATINGS, payload: Array<IRating> };
export type SetFilteredSerialsAction = { type: typeof FILTER_SERIALS, payload: Array<ISerial> };

export const setSerials = (serials: Array<ISerial>): SetSerialsAction => ({ type: SET_SERIALS, payload: serials });
export const filterSerials = (serials: Array<ISerial>): SetFilteredSerialsAction => ({ type: FILTER_SERIALS, payload: serials });
export const setSerial = (serial: ISerialWithRatings): SetModalContentAction => ({ type: SET_SERIAL, payload: serial });
export const setisFetching = (isFetching: boolean): SetIsFetchingAction => ({ type: SET_IS_FETCHING, payload: isFetching });
export const setRatings = (ratings: Array<IRating>): SetRatingsAction => ({ type: SET_RATINGS, payload: ratings });