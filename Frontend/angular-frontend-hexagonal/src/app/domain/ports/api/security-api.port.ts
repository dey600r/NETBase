import { IUserModel } from "@models/index";

export interface ISecurityApiPort {
    login(email: string, password: string): Promise<IUserModel>;
    signup(firstName: string, lastName: string, location: string, userName: string, email: string, password: string): Promise<IUserModel>;
    getUser(): Promise<IUserModel>;
}

export abstract class SecurityApiPort implements ISecurityApiPort {
    abstract login(email: string, password: string): Promise<IUserModel>;
    abstract signup(firstName: string, lastName: string, location: string, userName: string, email: string, password: string): Promise<IUserModel>;
    abstract getUser(): Promise<IUserModel>;
}