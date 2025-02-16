import { IUserModel } from "@models/index";

export interface IUserUIPort {
    setUser(user: IUserModel): void;
    getUser(): IUserModel | null;
    clearUser(): void;
}