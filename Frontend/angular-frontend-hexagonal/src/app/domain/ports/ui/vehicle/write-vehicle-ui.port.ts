import { IConfigurationModel } from "@models/index";

export interface IWriteVehicleUIPort {
    addConfiguration(conf: IConfigurationModel): Promise<IConfigurationModel>;
}

export abstract class WriteVehicleUIPort implements IWriteVehicleUIPort {
    abstract addConfiguration(conf: IConfigurationModel): Promise<IConfigurationModel>;
}