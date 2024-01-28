import { Injectable } from '@angular/core';
import { IConfigurationModel } from '@models/index';
import { UrlConstants } from '@utils/index';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class MaintenanceService {

  constructor(private httpService: HttpService) { }

  getAllConfiguration(): Promise<IConfigurationModel[]> {
    return this.httpService.get<IConfigurationModel[]>(UrlConstants.URL_API_MAINTENANCE_CONFIGURATION_GET_ALL);
  }
}
