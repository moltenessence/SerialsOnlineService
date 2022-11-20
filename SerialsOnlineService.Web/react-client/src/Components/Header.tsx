import { HeaderWrapper } from "./styles/Header.style";
import { GoogleLogin, GoogleLogout } from 'react-google-login';
import authService from "../Services/AuthService";
import { redirect } from "react-router-dom";

const Header = () => {

    const onSuccess = (response: any) => {
        authService.login(response).then((result) => {
            if (result) {
                console.log('success');

                localStorage.setItem('access_token', response.tokenId);

                window.history.replaceState({},
                    window.document.title,
                    window.location.origin + window.location.pathname);
                window.location.reload();
            }
        });
    };

    const onLogout = () => {
        localStorage.removeItem('access_token');
        redirect('/');
    };

    const onFailure = () => {
        console.log('zaloopa');
    };

    return (
        <HeaderWrapper>
            <h1>SerialsOnlineCenter</h1>
            {localStorage.getItem('access_token') ?
            
                <a>Logout
                    <div>
                        <GoogleLogout clientId="364153709208-56ucs5l2p4jc9aao37jb6ek0ubal7g3l.apps.googleusercontent.com"
                            buttonText="login"
                            onLogoutSuccess={ () =>{
                                 localStorage.removeItem('access_token');
                                 window.location.href = '/';
                            } } />
                    </div>
                </a> :
                <a>Login
                <div>
                    <GoogleLogin clientId="364153709208-56ucs5l2p4jc9aao37jb6ek0ubal7g3l.apps.googleusercontent.com"
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
