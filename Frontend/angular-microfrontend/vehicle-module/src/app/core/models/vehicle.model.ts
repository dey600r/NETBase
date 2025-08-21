export interface IVehicleTypeModel {
    id: number;
    code: string;
    description: string;
    createdDate: Date;
}

export interface IConfigurationModel {
    id: number;
    name: string;
    description: string;
    master: boolean;
    createdDate: Date;
}