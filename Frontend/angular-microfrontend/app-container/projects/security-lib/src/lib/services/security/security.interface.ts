import { IUserModel } from "../../models/index";

export interface ISecurityService {
    //LOGIN
    login(email: string, password: string): Promise<IUserModel>;
    validateToken(roles: string[]): boolean;
    validateRoles(rolesToken: string[], rolesPage: string[]): boolean;
    user(): Promise<IUserModel>;
    logout(): void;

    // SIGN UP
    signup(firstName: string, lastName: string, location: string, userName: string, email: string, password: string): Promise<IUserModel>;
}

export abstract class SecurityAbstractService implements ISecurityService {
    //LOGIN
    abstract login(email: string, password: string): Promise<IUserModel>;
    abstract validateToken(roles: string[]): boolean;
    abstract validateRoles(rolesToken: string[], rolesPage: string[]): boolean;
    abstract user(): Promise<IUserModel>;
    abstract logout(): void;
    
    // SIGN UP
    abstract signup(firstName: string, lastName: string, location: string, userName: string, email: string, password: string): Promise<IUserModel>;
}