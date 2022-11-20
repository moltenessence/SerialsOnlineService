import { ITokenInfo } from "../Common/Models/ITokenInfo";

class TokenStorage {
    public static setToken(token: string): void {
        localStorage.setItem('access_token', token);
    }

    public static removeToken(): void {
        localStorage.removeItem('access_token');
    }

    public static getToken(): string | null {
        return localStorage.getItem('access_token');
    }

    public static setUserDataFromToken(user: string): void {
        sessionStorage.setItem('user', JSON.stringify(user));
    }

    public static removeUserDataFromToken(): void {
        sessionStorage.removeItem('user');
    }

    public static getUserDataStringFromToken(): string | null {
        return sessionStorage.getItem('user');
    }

    public static getUserDataFromToken(): ITokenInfo | null {
        const user = sessionStorage.getItem('user');
        if (user) {
            return JSON.parse(user);
        }
        return null;
    }
}

export default TokenStorage;