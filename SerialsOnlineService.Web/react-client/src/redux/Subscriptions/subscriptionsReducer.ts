import { SET_IS_FETCHING, SET_SUBSCRIPTIONS } from "./constants";
import * as actions from './actions';
import { ISubscription } from "../../Common/Models/ISubscription";

export type SubscriptionsState = {
    subscriptions: Array<ISubscription>,
    isFetching: boolean
};

let initialState: SubscriptionsState = {
    subscriptions: [],
    isFetching: false
};

export type SubscriptionsActions = ReturnType<typeof actions[keyof typeof actions]>;

const subscriptionsReducer = (state = initialState, action: SubscriptionsActions): SubscriptionsState => {
    switch (action.type) {
        case SET_SUBSCRIPTIONS: {
            return { ...state, subscriptions: action.payload }
        }
        case SET_IS_FETCHING: {
            return { ...state, isFetching: action.payload }
        }
        default:
            return state;
    }
}

export default subscriptionsReducer;