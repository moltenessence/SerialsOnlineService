import React from 'react';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { RoutePaths } from '../../Common/Routes';
import Home from '../Home';


const ApplicationRouter: React.FC = () => {
    return (
            <Routes>
                <Route path={RoutePaths.HomeRoute} element={<Home />} />
                <Route path={RoutePaths.SerialsRoute} element={<div>Serials</div>} />
                <Route path={RoutePaths.SubscriptionsRoute} element={<div>Subscriptions</div>} />
                <Route path={RoutePaths.PurchasesRoute} element={<div>Purchases</div>} />
                <Route path={RoutePaths.AccountRoute} element={<div>Account</div>} />
                <Route path={RoutePaths.LoginRoute} element={<div>Login</div>} />
                <Route path={RoutePaths.RegisterRoute} element={<div>Register</div>} />
            </Routes>
    );
}

export default ApplicationRouter;