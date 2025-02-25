

import { inject, Injectable } from '@angular/core';

// MODELS
import { IConfigurationModel, IMaintenanceElementModel } from '@models/index';

// PORTS
import { IReadMaintenanceUIPort, IMaintenanceApiPort, MaintenanceApiPort } from '@ports/index';

@Injectable({
  providedIn: 'root'
})
export class ReadMaintenanceDomain implements IReadMaintenanceUIPort {

    // INJECTABLES
    private readonly _maintenanceApi: IMaintenanceApiPort = inject(MaintenanceApiPort);

    getAllMaintenanceElement(): Promise<IMaintenanceElementModel[]> {
        return this._maintenanceApi.getAllMaintenanceElement();
    }

    getAllConfiguration(): Promise<IConfigurationModel[]> {
        return this._maintenanceApi.getAllConfiguration();
    }
    
}