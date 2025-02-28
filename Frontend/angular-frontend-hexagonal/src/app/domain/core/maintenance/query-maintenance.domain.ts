

import { inject, Injectable } from '@angular/core';

// MODELS
import { IConfigurationModel, IMaintenanceElementModel } from '@models/index';

// PORTS
import { IQueryMaintenanceUIPort, IMaintenanceApiPort, MaintenanceApiPort } from '@ports/index';

@Injectable({
  providedIn: 'root'
})
export class QueryMaintenanceDomain implements IQueryMaintenanceUIPort {

    // INJECTABLES
    private readonly _maintenanceApi: IMaintenanceApiPort = inject(MaintenanceApiPort);

    getAllMaintenanceElement(): Promise<IMaintenanceElementModel[]> {
        return this._maintenanceApi.getAllMaintenanceElement();
    }

    getAllConfiguration(): Promise<IConfigurationModel[]> {
        return this._maintenanceApi.getAllConfiguration();
    }
    
}