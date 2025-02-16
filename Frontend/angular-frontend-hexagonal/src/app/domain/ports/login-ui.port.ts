import { IUserModel } from "@models/index";

export interface ILoginUIPort {
    login(email: string, password: string): Promise<IUserModel>;
}