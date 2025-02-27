import { IResponseModel, ISettingModel } from "@models/index";

export interface ISettingApiPort {
    getAllSettings(): Promise<IResponseModel<ISettingModel[]>>;
    addSetting(setting: ISettingModel): Promise<IResponseModel<ISettingModel>>;
}

export abstract class SettingApiPort implements ISettingApiPort {
    abstract getAllSettings(): Promise<IResponseModel<ISettingModel[]>>;
    abstract addSetting(setting: ISettingModel): Promise<IResponseModel<ISettingModel>>;
}
