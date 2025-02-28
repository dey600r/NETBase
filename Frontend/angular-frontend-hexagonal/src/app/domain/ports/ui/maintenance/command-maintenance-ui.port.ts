import { IMaintenanceElementModel } from "@models/index";

export interface ICommandMaintenanceUIPort {
    addMaintenanceElement(data: IMaintenanceElementModel): Promise<IMaintenanceElementModel>;
}

export abstract class CommandMaintenanceUIPort implements ICommandMaintenanceUIPort {
    abstract addMaintenanceElement(data: IMaintenanceElementModel): Promise<IMaintenanceElementModel>;
}
