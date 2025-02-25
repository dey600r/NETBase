

import { inject, Injectable } from '@angular/core';

// MODELS
import { IMaintenanceElementModel } from '@models/index';

// PORTS
import { IWriteMaintenanceUIPort, IMaintenanceApiPort, MaintenanceApiPort } from '@ports/index';

@Injectable({
  providedIn: 'root'
})
export class WriteMaintenanceDomain implements IWriteMaintenanceUIPort {

    // INJECTABLES
    private readonly _maintenanceApi: IMaintenanceApiPort = inject(MaintenanceApiPort);

    addMaintenanceElement(data: IMaintenanceElementModel): Promise<IMaintenanceElementModel> {
        return this._maintenanceApi.addMaintenanceElement(data);
    }
    
}