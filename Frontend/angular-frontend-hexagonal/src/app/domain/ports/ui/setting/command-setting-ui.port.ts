import { IResponseModel, ISettingModel } from "@models/index";

export interface ICommandSettingUIPort {
    addSetting(setting: ISettingModel): Promise<IResponseModel<ISettingModel>>;
}

export abstract class CommandSettingUIPort implements ICommandSettingUIPort {
    abstract addSetting(setting: ISettingModel): Promise<IResponseModel<ISettingModel>>;
}