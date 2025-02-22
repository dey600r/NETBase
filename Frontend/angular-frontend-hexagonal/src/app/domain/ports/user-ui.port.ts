import { IUserModel } from "@models/index";

export interface IUserUIPort {
    setUser(user: IUserModel): void;
    getUser(): IUserModel | null;
    clearUser(): void;
}

export abstract class UserUIPort implements IUserUIPort {
    abstract setUser(user: IUserModel): void;
    abstract getUser(): IUserModel | null;
    abstract clearUser(): void;
}