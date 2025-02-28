import { IConfigurationModel, IMaintenanceElementModel, IVehicleTypeModel } from "@models/index";

export interface IQueryVehicleUIPort {
    getAllVehicleType(): Promise<IVehicleTypeModel[]>;
    getAllConfiguration(): Promise<IConfigurationModel[]>;
    getAllMaintenanceElmenet(): Promise<IMaintenanceElementModel[]>;
}

export abstract class QueryVehicleUIPort implements IQueryVehicleUIPort {
    abstract getAllVehicleType(): Promise<IVehicleTypeModel[]>;
    abstract getAllConfiguration(): Promise<IConfigurationModel[]>;
    abstract getAllMaintenanceElmenet(): Promise<IMaintenanceElementModel[]>;
}