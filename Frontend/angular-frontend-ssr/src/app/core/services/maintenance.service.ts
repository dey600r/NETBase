import { Injectable } from '@angular/core';
import { IConfigurationModel, IMaintenanceElementModel } from '@models/index';
import { UrlConstants } from '@utils/index';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class MaintenanceService {

  constructor(private httpService: HttpService) { }

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
