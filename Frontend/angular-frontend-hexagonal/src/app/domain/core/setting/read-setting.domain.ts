import { inject, Injectable } from "@angular/core";

// MODELS
import { IResponseModel, ISettingModel } from "@models/index";

// PORTS
import { IReadSettingUIPort, ISettingApiPort, SettingApiPort } from "@ports/index";

@Injectable({
  providedIn: 'root'
})
export class ReadSettingDomain implements IReadSettingUIPort {
    
    // INJECTABLES
    private readonly _settingApi: ISettingApiPort = inject(SettingApiPort);
    
    getAllSettings(): Promise<IResponseModel<ISettingModel[]>> {
        return this._settingApi.getAllSettings();
    }
   
}

