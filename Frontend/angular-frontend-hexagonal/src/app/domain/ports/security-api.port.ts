import { IUserModel } from "@models/index";

export interface ISecurityApiPort {
    login(email: string, password: string): Promise<IUserModel>;
    signup(firstName: string, lastName: string, location: string, userName: string, email: string, password: string): Promise<IUserModel>;
}