import { IResponseModel, ISettingModel } from "@models/index";

export interface IReadSettingUIPort {
    getAllSettings(): Promise<IResponseModel<ISettingModel[]>>;
}

export abstract class ReadSettingUIPort implements IReadSettingUIPort {
    abstract getAllSettings(): Promise<IResponseModel<ISettingModel[]>>;
}