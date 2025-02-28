import { IConfigurationModel } from "@models/index";

export interface ICommandVehicleUIPort {
    addConfiguration(conf: IConfigurationModel): Promise<IConfigurationModel>;
}

export abstract class CommandVehicleUIPort implements ICommandVehicleUIPort {
    abstract addConfiguration(conf: IConfigurationModel): Promise<IConfigurationModel>;
}