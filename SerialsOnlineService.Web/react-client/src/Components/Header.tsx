import { HeaderWrapper } from "./styles/Header.style";
import { GoogleLogin, GoogleLogout } from 'react-google-login';
import authService from "../Services/AuthService";
import tokenStorage from "../Services/TokenStorage";
import { GOOGLE_CLIENT_ID } from "../Common/Constants";

const Header = () => {

    const onSuccess = (response: any) => {
        authService.login(response).then((result) => {
            if (result) {
                console.log('success');

                tokenStorage.setToken(response.tokenId);
                tokenStorage.setUserDataFromToken(response.profileObj);

                window.history.replaceState({},
                    window.document.title,
                    window.location.origin + window.location.pathname);
                window.location.reload();
            }
        });
    };

    const onLogout = () => {
        tokenStorage.removeToken();
        tokenStorage.removeUserDataFromToken();
        window.location.href = '/';
    };

    const onFailure = () => {
        console.log('Failure while logging in.');
    };

    return (
        <HeaderWrapper>
            <h1>SerialsOnlineCenter</h1>
            {tokenStorage.getToken() ?
                <a>Logout
                    <div>
                        <GoogleLogout clientId={GOOGLE_CLIENT_ID}
                            buttonText="login"
                            onLogoutSuccess={onLogout} />
                    </div>
                </a> :
                <a>Login
                <div>
                    <GoogleLogin clientId={GOOGLE_CLIENT_ID}
                        buttonText="Login"
                        onSuccess={onSuccess}
                        onFailure={onFailure}
                        isSignedIn={true} />
                </div>
            </a>
            }

        </HeaderWrapper>
    );
};

export default Header;
