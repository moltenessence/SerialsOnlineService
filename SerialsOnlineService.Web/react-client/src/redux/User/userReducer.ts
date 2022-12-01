import { SET_IS_FETCHING, SET_SUBSCRIPTION, SET_USER } from "./constants";
import * as actions from './actions';
import { IUser } from "../../Common/Models/IUser";
import { ISubscription } from "../../Common/Models/ISubscription";

export type UserState = {
    user: IUser | null,
    isFetching: boolean,
    subscription: ISubscription | null
};

let initialState: UserState = {
    user: null,
    isFetching: false,
    subscription: null
};

export type UserActions = ReturnType<typeof actions[keyof typeof actions]>;

const userReducer = (state = initialState, action: UserActions): UserState => {
    switch (action.type) {
        case SET_USER: {
            return { ...state, user: action.payload }
        }
        case SET_IS_FETCHING: {
            return { ...state, isFetching: action.payload }
        }
        case SET_SUBSCRIPTION: {
            return { ...state, subscription: action.payload }
        }
        default:
            return state;
    }
}

export default userReducer;