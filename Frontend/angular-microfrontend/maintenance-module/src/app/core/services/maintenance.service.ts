import { inject, Injectable } from '@angular/core';

import { HttpService } from 'security-lib';

// MODELS
import { IConfigurationModel, IMaintenanceElementModel } from '@models/index';
import { UrlConstants } from '@utils/index';

@Injectable({
  providedIn: 'root'
})
export class MaintenanceService {

  // INJECTABLES
  private readonly httpService: HttpService = inject(HttpService);

  getAllMaintenanceElement(): Promise<IMaintenanceElementModel[]> {
    return this.httpService.get<IMaintenanceElementModel[]>(UrlConstants.URL_API_MAINTENANCE_ELEMENT_GET_ALL);
  }

  getAllConfiguration(): Promise<IConfigurationModel[]> {
    return this.httpService.get<IConfigurationModel[]>(UrlConstants.URL_API_MAINTENANCE_CONFIGURATION_GET_ALL);
  }

  addMaintenanceElement(data: IMaintenanceElementModel): Promise<IMaintenanceElementModel> {
    return this.httpService.post<IMaintenanceElementModel, IMaintenanceElementModel>(UrlConstants.URL_API_MAINTENANCE_ELEMENT_GET_ALL, data);
  }
}
