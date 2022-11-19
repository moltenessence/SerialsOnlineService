import { HeaderWrapper } from "./styles/Header.style";
import { RoutePaths } from "../Common/Routes";
import {NavLink} from "react-router-dom";

const Header = () => {
    return (
        <HeaderWrapper>
            <h1>SerialsOnlineCenter</h1>
            <NavLink to={RoutePaths.LoginRoute}>Login</NavLink>
        </HeaderWrapper>
    );
};

export default Header;
