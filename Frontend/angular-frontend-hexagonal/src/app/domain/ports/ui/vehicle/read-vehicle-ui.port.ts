import { IConfigurationModel, IMaintenanceElementModel, IVehicleTypeModel } from "@models/index";

export interface IReadVehicleUIPort {
    getAllVehicleType(): Promise<IVehicleTypeModel[]>;
    getAllConfiguration(): Promise<IConfigurationModel[]>;
    getAllMaintenanceElmenet(): Promise<IMaintenanceElementModel[]>;
}

export abstract class ReadVehicleUIPort implements IReadVehicleUIPort {
    abstract getAllVehicleType(): Promise<IVehicleTypeModel[]>;
    abstract getAllConfiguration(): Promise<IConfigurationModel[]>;
    abstract getAllMaintenanceElmenet(): Promise<IMaintenanceElementModel[]>;
}