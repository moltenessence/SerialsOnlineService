import subscriptionsService from "../../Services/SubscriptionsService";
import { SubscriptionsActions } from "./subscriptionsReducer";
import { AppDispatch } from "../store";
import { setisFetching, setSubscriptions } from "./actions";
import { ISubscriptionFilter } from "../../Common/Models/ISubscriptionsFilter";

export const fetchSubscriptions = () => {
    return async (dispatch: AppDispatch<SubscriptionsActions>) => {
        dispatch(setisFetching(true));
        await subscriptionsService.getAll().then((subscriptions) => {
            dispatch(setSubscriptions(subscriptions));
            dispatch(setisFetching(false));
        });
    };
};

export const filterSubscriptions = (filter: ISubscriptionFilter) => {
    return async (dispatch: AppDispatch<SubscriptionsActions>) => {
        dispatch(setisFetching(true));
        await subscriptionsService.getByPrice(filter).then((subscriptions) => {
            dispatch(setSubscriptions(subscriptions));
            dispatch(setisFetching(false));
        });
    };
};

