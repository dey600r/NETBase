

import { inject, Injectable } from '@angular/core';

// MODELS
import { IMaintenanceElementModel } from '@models/index';

// PORTS
import { ICommandMaintenanceUIPort, IMaintenanceApiPort, MaintenanceApiPort } from '@ports/index';

@Injectable({
  providedIn: 'root'
})
export class CommandMaintenanceDomain implements ICommandMaintenanceUIPort {

    // INJECTABLES
    private readonly _maintenanceApi: IMaintenanceApiPort = inject(MaintenanceApiPort);

    addMaintenanceElement(data: IMaintenanceElementModel): Promise<IMaintenanceElementModel> {
        return this._maintenanceApi.addMaintenanceElement(data);
    }
    
}