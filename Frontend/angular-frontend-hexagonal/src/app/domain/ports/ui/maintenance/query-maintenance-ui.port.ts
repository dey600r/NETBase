import { IConfigurationModel, IMaintenanceElementModel } from "@app/domain/models";

export interface IQueryMaintenanceUIPort {
    getAllMaintenanceElement(): Promise<IMaintenanceElementModel[]>;
    getAllConfiguration(): Promise<IConfigurationModel[]>;
}

export abstract class QueryMaintenanceUIPort implements IQueryMaintenanceUIPort {
    abstract getAllMaintenanceElement(): Promise<IMaintenanceElementModel[]>;
    abstract getAllConfiguration(): Promise<IConfigurationModel[]>;
}
