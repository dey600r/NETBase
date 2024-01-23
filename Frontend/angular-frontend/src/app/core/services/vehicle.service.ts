import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { IConfigurationModel, IVehicleTypeModel } from '@models/index';
import { UrlConstants } from '@utils/index';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  constructor(private httpService: HttpService) { }

  getAllVehicleType(): Promise<IVehicleTypeModel[]> {
    return this.httpService.get<IVehicleTypeModel[]>(UrlConstants.URL_API_VEHICLE_TYPE_GET_ALL);
  }

  getAllConfiguration(): Promise<IConfigurationModel[]> {
    return this.httpService.get<IConfigurationModel[]>(UrlConstants.URL_API_CONFIGURATION_GET_ALL);
  }
}
