import { combineReducers, applyMiddleware, legacy_createStore as createStore } from 'redux';
import thunkMiddleware from 'redux-thunk';
import { Action } from 'redux';
import { ThunkDispatch } from 'redux-thunk';
import serialsReducer from './Serials/serialsReducer';
import subscriptionsReducer from './Subscriptions/subscriptionsReducer';

const RootReducer = combineReducers({
    serialsPage: serialsReducer,
    subscriptionsPage: subscriptionsReducer
});

const store = createStore(RootReducer, applyMiddleware(thunkMiddleware));

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch<T extends Action> = ThunkDispatch<RootState, unknown, T>;

export default store;