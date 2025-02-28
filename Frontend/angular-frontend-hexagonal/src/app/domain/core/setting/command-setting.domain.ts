import { inject, Injectable } from "@angular/core";

// MODELS
import { IResponseModel, ISettingModel } from "@models/index";

// PORTS
import { ISettingApiPort, ICommandSettingUIPort, SettingApiPort } from "@ports/index";

@Injectable({
  providedIn: 'root'
})
export class CommandSettingDomain implements ICommandSettingUIPort {
  
  // INJECTABLES
  private readonly _settingApi: ISettingApiPort = inject(SettingApiPort);
  
  addSetting(setting: ISettingModel): Promise<IResponseModel<ISettingModel>> {
    return this._settingApi.addSetting(setting);
  }

}
