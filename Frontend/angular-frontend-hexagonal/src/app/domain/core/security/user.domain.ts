import { inject, Injectable } from '@angular/core';

// MODELS
import { IUserModel } from '@models/index';
import { AppConstants } from '@utils/index';

// PORTS
import { IStorageDatabasePort, StorageDatabasePort, UserUIPort } from '@app/domain/ports/index';

@Injectable({
  providedIn: 'root'
})
export class UserDomain implements UserUIPort {

  // INJECTABLES
  private readonly _databasePort: IStorageDatabasePort = inject(StorageDatabasePort);

  constructor() {
  }

  setUser(user: IUserModel): void {
    this._databasePort.setData<IUserModel>(AppConstants.LOCAL_STORAGE_USER, user);
  }

  getUser(): IUserModel | null {
    const user = this._databasePort.getData(AppConstants.LOCAL_STORAGE_USER);
    return (!user ? null : JSON.parse(user) as IUserModel);
  }

  clearUser(): void {
    this._databasePort.removeData(AppConstants.LOCAL_STORAGE_USER);
  }


}
