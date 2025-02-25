import { IUserModel } from "@models/index";

export interface ISignupUIPort {
    signup(firstName: string, lastName: string, location: string, userName: string, email: string, password: string): Promise<IUserModel>;
}

export abstract class SignupUIPort {
    abstract signup(firstName: string, lastName: string, location: string, userName: string, email: string, password: string): Promise<IUserModel>;
}