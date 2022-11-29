import { ISerial } from "../../Common/Models/ISerial";
import { SET_IS_FETCHING, SET_SERIALS, SET_SERIAL } from "./constants";
import * as actions from './actions';
import { ISerialWithRatings } from "../../Common/Models/ISerialWithRatings";

export type SerialsState = {
    serials: Array<ISerial>,
    modalContent: ISerialWithRatings | null,
    isFetching: boolean
};

let initialState: SerialsState = {
    serials: [],
    modalContent: null,
    isFetching: false
};

export type SerialsActions = ReturnType<typeof actions[keyof typeof actions]>;

const serialsReducer = (state = initialState, action: SerialsActions): SerialsState => {
    switch (action.type) {
        case SET_SERIALS: {
            return { ...state, serials: action.payload }
        }
        case SET_SERIAL: {
            return { ...state, modalContent: action.payload }
        }
        case SET_IS_FETCHING: {
            return { ...state, isFetching: action.payload }
        }
        default:
            return state;
    }
}

export default serialsReducer;