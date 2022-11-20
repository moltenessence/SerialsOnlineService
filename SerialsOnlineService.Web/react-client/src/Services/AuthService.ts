import { axiosInstance } from '../utils/axios';
import { GoogleLoginResponse } from 'react-google-login';
import { ICreateUserRequest } from '../Common/Models/IUser';
import { ILogin } from '../Common/Models/ILogin';

class AuthService {
    public static async login(reponse: GoogleLoginResponse): Promise<boolean> {;
        const user : ICreateUserRequest = {
            email: reponse.profileObj.email,
            userName: reponse.profileObj.name,
            age: 18
        }

        const request: ILogin = {
            user: user
        }

        const result = await axiosInstance.post(`api/Auth/login`, {...request}).
            then((response) => response.data)
            .catch((error) => {
                console.log(error);
            });
            
        return result;
    }
}

export default AuthService;