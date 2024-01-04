export interface IUserModel {
    id: string,
    email: string,
    userName: string,
    firstName: string,
    lastName: string,
    token: string,
    roles: string[]
}

export interface ILoginModel {
    email: string;
    password: string;
}