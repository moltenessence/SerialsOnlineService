import subscriptionsService from "../../Services/SubscriptionsService";
import { SubscriptionsActions } from "./subscriptionsReducer";
import { AppDispatch } from "../store";
import { setisFetching, setSubscriptions } from "./actions";

export const fetchSubscriptions = () => {
    return async (dispatch: AppDispatch<SubscriptionsActions>) => {
        dispatch(setisFetching(true));
        await subscriptionsService.getAll().then((subscriptions) => {
            dispatch(setSubscriptions(subscriptions));
            dispatch(setisFetching(false));
        });
    };
};


