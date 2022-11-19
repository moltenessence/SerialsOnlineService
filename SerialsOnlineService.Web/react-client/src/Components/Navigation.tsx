import { NavLink } from "react-router-dom";
import {RoutePaths} from "../Common/Routes";
import { NavWrapper } from "./styles/Nav.style";

const Navigation = () => {
    return (
        <NavWrapper>
            <NavLink to={RoutePaths.HomeRoute}>Home</NavLink>
            <NavLink to={RoutePaths.SerialsRoute}>Serials</NavLink>
            <NavLink to={RoutePaths.SubscriptionsRoute}>Subscriptions</NavLink>
            <NavLink to={RoutePaths.PurchasesRoute}>Purchases</NavLink>
            <NavLink to={RoutePaths.AccountRoute}>Account</NavLink>
        </NavWrapper>
    );
};

export default Navigation;