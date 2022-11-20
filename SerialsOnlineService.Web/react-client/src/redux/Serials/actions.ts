
import { SET_IS_FETCHING, SET_SERIALS, SET_SERIAL } from "./constants";
import { ISerial } from "../../Common/Models/ISerial";

export type SetSerialsAction = { type: typeof SET_SERIALS, payload: Array<ISerial> };
export type SetIsFetchingAction = { type: typeof SET_IS_FETCHING, payload: boolean };
export type SetModalContentAction = { type: typeof SET_SERIAL, payload: ISerial | null };

export const setSerials = (serials: Array<ISerial>): SetSerialsAction => ({ type: SET_SERIALS, payload: serials });
export const setSerial = (serial: ISerial): SetModalContentAction => ({ type: SET_SERIAL, payload: serial });
export const setisFetching = (isFetching: boolean): SetIsFetchingAction => ({ type: SET_IS_FETCHING, payload: isFetching });