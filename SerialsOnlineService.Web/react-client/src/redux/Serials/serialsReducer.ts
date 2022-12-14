import { ISerial } from "../../Common/Models/ISerial";
import { SET_IS_FETCHING, SET_SERIALS, SET_SERIAL, SET_RATINGS, FILTER_SERIALS, SET_GENRES } from "./constants";
import * as actions from './actions';
import { ISerialWithRatings } from "../../Common/Models/ISerialWithRatings";
import { IRating } from "../../Common/Models/IRating";
import { IGroupedGenres } from "../../Common/Models/IGropedGenres";

export type SerialsState = {
    serials: Array<ISerial>,
    modalContent: ISerialWithRatings | null,
    isFetching: boolean,
    ratings:  Array<IRating> | null,
    genres: Array<IGroupedGenres>
};

let initialState: SerialsState = {
    serials: [],
    modalContent: null,
    isFetching: false,
    ratings: null,
    genres: []
};

export type SerialsActions = ReturnType<typeof actions[keyof typeof actions]>;

const serialsReducer = (state = initialState, action: SerialsActions): SerialsState => {
    switch (action.type) {
        case SET_SERIALS: {
            return { ...state, serials: action.payload }
        }
        case FILTER_SERIALS: {
            return { ...state, serials: action.payload }
        }
        case SET_SERIAL: {
            return { ...state, modalContent: action.payload }
        }
        case SET_IS_FETCHING: {
            return { ...state, isFetching: action.payload }
        }
        case SET_RATINGS: {
            return { ...state, ratings: action.payload }
        }
        case SET_GENRES: {
            return {...state, genres: action.payload }
        }
        default:
            return state;
    }
}

export default serialsReducer;