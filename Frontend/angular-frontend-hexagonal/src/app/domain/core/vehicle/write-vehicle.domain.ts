import { inject, Injectable } from "@angular/core";

// MODELS
import { IConfigurationModel } from "@models/index";

// PORTS
import { IVehicleApiPort, IWriteVehicleUIPort, VehicleApiPort } from "@ports/index";

@Injectable({
  providedIn: 'root'
})
export class WriteVehicleDomain implements IWriteVehicleUIPort {

    // INJECTABLES
    private readonly _vehicleApi: IVehicleApiPort = inject(VehicleApiPort);

    addConfiguration(conf: IConfigurationModel): Promise<IConfigurationModel> {
        return this._vehicleApi.addConfiguration(conf);
    }
}
