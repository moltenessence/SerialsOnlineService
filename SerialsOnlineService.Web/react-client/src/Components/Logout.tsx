import GoogleLogin, { GoogleLoginProps, GoogleLoginResponse, GoogleLogout } from "react-google-login";

const Logout = () => {

    const onSuccess = () => {
        console.log('logout');
    };

    return (
        <div>
            <GoogleLogout clientId="364153709208-56ucs5l2p4jc9aao37jb6ek0ubal7g3l.apps.googleusercontent.com"
            buttonText="login"
            onLogoutSuccess={onSuccess}/>
        </div>
    );
};

export default Logout;