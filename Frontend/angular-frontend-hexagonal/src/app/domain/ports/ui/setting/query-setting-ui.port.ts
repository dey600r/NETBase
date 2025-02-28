import { IResponseModel, ISettingModel } from "@models/index";

export interface IQuerySettingUIPort {
    getAllSettings(): Promise<IResponseModel<ISettingModel[]>>;
}

export abstract class QuerySettingUIPort implements IQuerySettingUIPort {
    abstract getAllSettings(): Promise<IResponseModel<ISettingModel[]>>;
}