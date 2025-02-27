import { inject, Injectable } from '@angular/core';
import { HttpService } from './http.service';

// MODELS
import { UrlConstants } from '@utils/index';
import { ISettingModel, IResponseModel } from '@models/index';

// PORTS
import { ISettingApiPort } from '@ports/index';

@Injectable({
  providedIn: 'root'
})
export class SettingService implements ISettingApiPort {

  private readonly httpService: HttpService = inject(HttpService);

  getAllSettings(): Promise<IResponseModel<ISettingModel[]>> {
    return this.httpService.get<IResponseModel<ISettingModel[]>>(UrlConstants.URL_API_SETTING_GET_ALL);
  }

  addSetting(setting: ISettingModel): Promise<IResponseModel<ISettingModel>> {
    return this.httpService.post<ISettingModel, IResponseModel<ISettingModel>>(UrlConstants.URL_API_SETTING_ADD, setting);
  }
}
