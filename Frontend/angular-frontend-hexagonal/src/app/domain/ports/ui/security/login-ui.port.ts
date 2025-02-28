import { IUserModel } from "@models/index";

export interface ILoginUIPort {
    login(email: string, password: string): Promise<IUserModel>;
    validateToken(roles: string[]): boolean;
    validateRoles(rolesToken: string[], rolesPage: string[]): boolean;
    user(): Promise<IUserModel>;
    logout(): void;
}

export abstract class LoginUIPort implements ILoginUIPort {
    abstract login(email: string, password: string): Promise<IUserModel>;
    abstract validateToken(roles: string[]): boolean;
    abstract validateRoles(rolesToken: string[], rolesPage: string[]): boolean;
    abstract user(): Promise<IUserModel>;
    abstract logout(): void;
}