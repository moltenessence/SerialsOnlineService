export interface IUser {
    id: number;
    userName: string;
    age?: number;
    email: string;
    subscriptionId?: number;
}

export interface IUpdateUserRequest {
    id: number;
    userName: string;
    age?: number;
    email: string;
    subscriptionId?: number;
}

export interface ICreateUserRequest {
    userName: string;
    age?: number;
    email: string;
}