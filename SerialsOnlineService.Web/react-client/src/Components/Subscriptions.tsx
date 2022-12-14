import React, { useEffect, useState } from 'react';
import { Dispatch, bindActionCreators } from "redux";
import { RootState } from "../redux/store";
import { ReactJSXIntrinsicAttributes } from '@emotion/react/types/jsx-namespace';
import * as subscriptionsActionCreators from '../redux/Subscriptions/actionCreators'
import { getIsFetching, getSubscriptions } from '../redux/Subscriptions/selectors';
import Preloader from './other/Preloader';
import { connect } from 'react-redux';
import { ISubscription } from '../Common/Models/ISubscription';
import { SubscriptionItem, SubscriptionsWrapper } from "./styles/Subscriptions.style";
import * as purchasesActionCreators from '../redux/Purchases/actionCreators';
import PurchaseButton from './other/PurchaseButton';
import PurchaseForm from './forms/PurchaseForm';
import tokenStorage from '../Services/TokenStorage';
import SubscriptionsFilterForm from './forms/SubscriptionsFilterForm';

function mapStateToProps(state: RootState) {
    return {
        subscriptions: getSubscriptions(state),
        isFetching: getIsFetching(state),
    };
}

const mapDispatchToProps = (dispatch: Dispatch) => bindActionCreators({
    fetchSubscriptions: subscriptionsActionCreators.fetchSubscriptions,
    makePurchase: purchasesActionCreators.makePurchase,
    filterSubscriptions: subscriptionsActionCreators.filterSubscriptions
}, dispatch);

type SerialsProps = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps> & ReactJSXIntrinsicAttributes

const Serials: React.FC<SerialsProps> = ({ subscriptions, isFetching, fetchSubscriptions, makePurchase, filterSubscriptions }) => {

    const [isFormOpened, setFormOpened] = useState(false);
    const [isAuth, setAuth] = useState(false);

    useEffect(() => {
        fetchSubscriptions();
        setAuth(tokenStorage.getUserDataFromToken() ? true : false);
    }, []);

    const subscriptionsList = subscriptions?.map((subscription: ISubscription) => {
        return (
            <SubscriptionItem key={subscription.id}>
                <h3>{subscription.name}</h3>
                <p>Price: {subscription.pricePerMonth}$</p>
                {isAuth && <PurchaseButton callback={() => { setFormOpened(!isFormOpened); }} />}
                {isFormOpened && <PurchaseForm subscriptionId={subscription.id} makePurchase={makePurchase}/>}
            </SubscriptionItem>
        );
    });

    return (
        <SubscriptionsWrapper>
            {isFetching ? <Preloader /> : null}
            <SubscriptionsFilterForm filterData={filterSubscriptions} />
            {subscriptionsList.length ? subscriptionsList : <p>No subscriptions available.</p>}
        </SubscriptionsWrapper>
    );
};


export default connect(mapStateToProps, mapDispatchToProps)(Serials);