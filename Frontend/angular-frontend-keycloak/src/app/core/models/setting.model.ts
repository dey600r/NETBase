export interface ISettingModel {
    _id: string;
    key: string;
    value: string;
    updated: Date;
}

export interface IResponseModel<T> {
    ok: boolean;
    data: T;
}