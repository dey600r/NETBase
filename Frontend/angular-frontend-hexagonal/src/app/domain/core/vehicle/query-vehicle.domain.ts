import { inject, Injectable } from "@angular/core";

// MODELS
import { IConfigurationModel, IMaintenanceElementModel, IVehicleTypeModel } from "@models/index";

// PORTS
import { IQueryVehicleUIPort, IVehicleApiPort, VehicleApiPort } from "@ports/index";

@Injectable({
  providedIn: 'root'
})
export class QueryVehicleDomain implements IQueryVehicleUIPort {

    // INJECTABLES
    private readonly _vehicleApi: IVehicleApiPort = inject(VehicleApiPort);

    getAllVehicleType(): Promise<IVehicleTypeModel[]> {
        return this._vehicleApi.getAllVehicleType();
    }

    getAllConfiguration(): Promise<IConfigurationModel[]> {
        return this._vehicleApi.getAllConfiguration();
    }
    
    getAllMaintenanceElmenet(): Promise<IMaintenanceElementModel[]> {
        return this._vehicleApi.getAllMaintenanceElmenet();
    }
}

