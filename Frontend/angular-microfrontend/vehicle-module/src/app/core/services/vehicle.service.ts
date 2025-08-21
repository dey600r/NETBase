import { inject, Injectable } from '@angular/core';
import { HttpService } from './http.service';

// MODELS
import { IConfigurationModel, IMaintenanceElementModel, IVehicleTypeModel } from '@models/index';
import { UrlConstants } from '@utils/index';


@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  private readonly httpService: HttpService = inject(HttpService);

  constructor() { }

  getAllVehicleType(): Promise<IVehicleTypeModel[]> {
    return this.httpService.get<IVehicleTypeModel[]>(UrlConstants.URL_API_VEHICLE_TYPE_GET_ALL);
  }

  getAllConfiguration(): Promise<IConfigurationModel[]> {
    return this.httpService.get<IConfigurationModel[]>(UrlConstants.URL_API_CONFIGURATION_GET_ALL);
  }

  addConfiguration(conf: IConfigurationModel): Promise<IConfigurationModel> {
    return this.httpService.post<IConfigurationModel, IConfigurationModel>(UrlConstants.URL_API_CONFIGURATION_GET_ALL, conf);
  }

  getAllMaintenanceElmenet(): Promise<IMaintenanceElementModel[]> {
    return this.httpService.get<IMaintenanceElementModel[]>(UrlConstants.URL_API_VEHICLE_MAINTENANCE_ELEMENT_GET_ALL);
  }
}
