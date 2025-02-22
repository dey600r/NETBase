import { IUserModel } from "@models/index";

export interface ILoginUIPort {
    login(email: string, password: string): Promise<IUserModel>;
}

export abstract class LoginUIPort implements ILoginUIPort {
    abstract login(email: string, password: string): Promise<IUserModel>;
}