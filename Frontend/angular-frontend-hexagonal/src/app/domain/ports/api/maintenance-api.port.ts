import { IConfigurationModel, IMaintenanceElementModel } from "@models/index";

export interface IMaintenanceApiPort {
    getAllMaintenanceElement(): Promise<IMaintenanceElementModel[]>;
    getAllConfiguration(): Promise<IConfigurationModel[]>;
    addMaintenanceElement(data: IMaintenanceElementModel): Promise<IMaintenanceElementModel>;
}

export abstract class MaintenanceApiPort implements IMaintenanceApiPort {
    abstract getAllMaintenanceElement(): Promise<IMaintenanceElementModel[]>;
    abstract getAllConfiguration(): Promise<IConfigurationModel[]>;
    abstract addMaintenanceElement(data: IMaintenanceElementModel): Promise<IMaintenanceElementModel>;
}
