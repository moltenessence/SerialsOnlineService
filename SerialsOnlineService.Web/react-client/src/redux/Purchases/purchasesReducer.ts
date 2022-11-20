import { SET_IS_FETCHING, SET_PURCHASES } from "./constants";
import * as actions from './actions';
import { IPurchase } from "../../Common/Models/IPurchase";

export type PurchasesState = {
    purchases: Array<IPurchase> | null,
    isFetching: boolean
};

let initialState: PurchasesState = {
    purchases: null,
    isFetching: false
};

export type PurchasesActions = ReturnType<typeof actions[keyof typeof actions]>;

const purchasesReducer = (state = initialState, action: PurchasesActions): PurchasesState => {
    switch (action.type) {
        case SET_PURCHASES: {
            return { ...state, purchases: action.payload }
        }
        case SET_IS_FETCHING: {
            return { ...state, isFetching: action.payload }
        }
        default:
            return state;
    }
}

export default purchasesReducer;