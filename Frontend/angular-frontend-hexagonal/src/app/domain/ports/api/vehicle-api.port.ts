import { IConfigurationModel, IMaintenanceElementModel, IVehicleTypeModel } from "@models/index";

export interface IVehicleApiPort {
    getAllVehicleType(): Promise<IVehicleTypeModel[]>;
    getAllConfiguration(): Promise<IConfigurationModel[]>;
    addConfiguration(conf: IConfigurationModel): Promise<IConfigurationModel>;
    getAllMaintenanceElmenet(): Promise<IMaintenanceElementModel[]>;
}

export abstract class VehicleApiPort implements IVehicleApiPort {
    abstract getAllVehicleType(): Promise<IVehicleTypeModel[]>;
    abstract getAllConfiguration(): Promise<IConfigurationModel[]>;
    abstract addConfiguration(conf: IConfigurationModel): Promise<IConfigurationModel>;
    abstract getAllMaintenanceElmenet(): Promise<IMaintenanceElementModel[]>;
}