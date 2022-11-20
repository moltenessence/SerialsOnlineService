import { PurchaseItem, PurchasesWrapper } from "./styles/Purchases.style";
import { getPurchases, isFetching } from "../redux/Purchases/selectors";
import { RootState } from "../redux/store";
import {bindActionCreators, Dispatch} from "redux";
import * as purchasesActionCreators from '../redux/Purchases/actionCreators'
import { ReactJSXIntrinsicAttributes } from '@emotion/react/types/jsx-namespace';
import Preloader from './other/Preloader';
import { connect } from 'react-redux';
import {useEffect} from "react";

function mapStateToProps(state: RootState) {
    return {
        purchases: getPurchases(state),
        isFetching: isFetching(state),
    };
}

const mapDispatchToProps = (dispatch: Dispatch) => bindActionCreators({
    fetchPurchases: purchasesActionCreators.fetchPurchases
}, dispatch);

type PurchasesProps = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps> & ReactJSXIntrinsicAttributes

const Purchases : React.FC<PurchasesProps> = ({purchases, isFetching, fetchPurchases}) => {

    useEffect(() => {
        fetchPurchases();
    }, []);

    return (
        <PurchasesWrapper>
            {isFetching ? <Preloader /> : null}
            <h1>Purchases</h1>
            {purchases?.map(purchase => {
                return (
                    <PurchaseItem key={purchase.id}>
                        <h3>Purchase #{purchase.id}</h3>
                        <p> Amount of months: {purchase.amountOfMonths}</p>
                        <p> Purchase date: {purchase.date}</p>
                        <p> Subscription: {purchase.subscription}</p>
                        <p>Total Price: {purchase.totalPrice}</p>
                    </PurchaseItem>
                );
            })}
        </PurchasesWrapper>
    );
};

export default connect(mapStateToProps, mapDispatchToProps)(Purchases);