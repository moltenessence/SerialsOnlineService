import { SET_IS_FETCHING, SET_USER } from "./constants";
import * as actions from './actions';
import { IUser } from "../../Common/Models/IUser";

export type UserState = {
    user: IUser | null,
    isFetching: boolean
};

let initialState: UserState = {
    user: null,
    isFetching: false
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
        default:
            return state;
    }
}

export default userReducer;