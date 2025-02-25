import { IConfigurationModel, IMaintenanceElementModel } from "@app/domain/models";

export interface IReadMaintenanceUIPort {
    getAllMaintenanceElement(): Promise<IMaintenanceElementModel[]>;
    getAllConfiguration(): Promise<IConfigurationModel[]>;
}

export abstract class ReadMaintenanceUIPort implements IReadMaintenanceUIPort {
    abstract getAllMaintenanceElement(): Promise<IMaintenanceElementModel[]>;
    abstract getAllConfiguration(): Promise<IConfigurationModel[]>;
}
