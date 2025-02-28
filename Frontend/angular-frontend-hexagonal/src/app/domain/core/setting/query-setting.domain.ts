import { inject, Injectable } from "@angular/core";

// MODELS
import { IResponseModel, ISettingModel } from "@models/index";

// PORTS
import { IQuerySettingUIPort, ISettingApiPort, SettingApiPort } from "@ports/index";

@Injectable({
  providedIn: 'root'
})
export class QuerySettingDomain implements IQuerySettingUIPort {
    
    // INJECTABLES
    private readonly _settingApi: ISettingApiPort = inject(SettingApiPort);
    
    getAllSettings(): Promise<IResponseModel<ISettingModel[]>> {
        return this._settingApi.getAllSettings();
    }
   
}

