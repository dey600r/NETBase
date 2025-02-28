import { inject, Injectable } from "@angular/core";

// MODELS
import { IConfigurationModel } from "@models/index";

// PORTS
import { IVehicleApiPort, ICommandVehicleUIPort, VehicleApiPort } from "@ports/index";

@Injectable({
  providedIn: 'root'
})
export class CommandVehicleDomain implements ICommandVehicleUIPort {

    // INJECTABLES
    private readonly _vehicleApi: IVehicleApiPort = inject(VehicleApiPort);

    addConfiguration(conf: IConfigurationModel): Promise<IConfigurationModel> {
        return this._vehicleApi.addConfiguration(conf);
    }
}
