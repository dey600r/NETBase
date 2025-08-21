import { inject, Injectable } from '@angular/core';

// SERVICES
import { StorageService } from '../storage.service';

// UTILS
import { IUserModel } from '../../models/index';
import { AppConstants } from '../../utils/index';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  protected readonly _storageService: StorageService = inject(StorageService);

  //#region USER

  setUser(user: IUserModel) {
    this._storageService.setData<IUserModel>(AppConstants.LOCAL_STORAGE_USER, user);
  }

  getUser(): IUserModel | null {
    const user = this._storageService.getData(AppConstants.LOCAL_STORAGE_USER);
    return (!user ? null : JSON.parse(user) as IUserModel);
  }

  clearUser(): void {
    this._storageService.removeData(AppConstants.LOCAL_STORAGE_USER);
  }

  //#endregion USER
}
