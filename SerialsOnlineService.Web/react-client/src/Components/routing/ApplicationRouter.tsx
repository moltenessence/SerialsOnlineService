import React from 'react';
import { Routes, Route } from "react-router-dom";
import { RoutePaths } from '../../Common/Routes';
import Account from '../Account';
import Home from '../Home';
import Serials from '../Serials';
import { SerialModal } from '../styles/Serials.style';
import Subscriptions from '../Subscriptions';
import Purchases from '../Purchases';

const ApplicationRouter: React.FC = () => {
    return (
        <Routes>
            <Route path={RoutePaths.HomeRoute} element={<Home />} />
            <Route path={RoutePaths.SerialsRoute} element={<Serials />}>
                <Route path={RoutePaths.ConcreteSerialRoute} element={<SerialModal />} />
            </Route>
            <Route path={RoutePaths.SubscriptionsRoute} element={<Subscriptions />} />
            <Route path={RoutePaths.PurchasesRoute} element={<Purchases />} />
            <Route path={RoutePaths.AccountRoute} element={<Account />} />
        </Routes>
    );
}

export default ApplicationRouter;