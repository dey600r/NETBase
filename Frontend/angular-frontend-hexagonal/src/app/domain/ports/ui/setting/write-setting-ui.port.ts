import { IResponseModel, ISettingModel } from "@models/index";

export interface IWriteSettingUIPort {
    addSetting(setting: ISettingModel): Promise<IResponseModel<ISettingModel>>;
}

export abstract class WriteSettingUIPort implements IWriteSettingUIPort {
    abstract addSetting(setting: ISettingModel): Promise<IResponseModel<ISettingModel>>;
}