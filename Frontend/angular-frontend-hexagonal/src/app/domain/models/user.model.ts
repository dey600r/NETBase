export interface IUserModel {
    id: string,
    email: string,
    userName: string,
    firstName: string,
    lastName: string,
    location: string,
    token: string,
    roles: string[]
}

export interface ILoginModel {
    email: string;
    password: string;
}

export interface ISignupModel {
    email: string,
    userName: string,
    firstName: string,
    lastName: string,
    location: string,
    password: string
}