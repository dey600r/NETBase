import { IMaintenanceElementModel } from "@models/index";

export interface IWriteMaintenanceUIPort {
    addMaintenanceElement(data: IMaintenanceElementModel): Promise<IMaintenanceElementModel>;
}

export abstract class WriteMaintenanceUIPort implements IWriteMaintenanceUIPort {
    abstract addMaintenanceElement(data: IMaintenanceElementModel): Promise<IMaintenanceElementModel>;
}
