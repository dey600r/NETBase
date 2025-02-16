import { inject, Injectable } from '@angular/core';

import { StorageService } from '@helpers/index';

import { AppConstants } from '@utils/index';
import { IUserModel } from '@models/index';
import { IUserUIPort } from '@ports/index';

@Injectable({
  providedIn: 'root'
})
export class UserDomain implements IUserUIPort {

    // INJECTABLES
    private readonly storageService: StorageService = inject(StorageService);

    constructor() {
    }

//   user(): Promise<IUserModel> {
//     if(environment.keycloak.enable) {
//       return new Promise((resolve, reject) => {
//         this.keycloak.getToken().then(token => {
//           this.keycloak.loadUserProfile().then((value: KeycloakProfile) => {
//             const user: IUserModel = {
//               email: (value.email ? value.email : AppConstants.UNKNOWN),
//               firstName: (value.firstName ? value.firstName : AppConstants.UNKNOWN),
//               lastName: (value.lastName ? value.lastName : AppConstants.UNKNOWN),
//               id: (value.id ? value.id : AppConstants.UNKNOWN),
//               location: AppConstants.UNKNOWN,
//               token: token,
//               userName: (value.username ? value.username : AppConstants.UNKNOWN),
//               roles: this.keycloak.getUserRoles()
//             };
//             this.setUser(user)
//             resolve(user);
//           });
//         });
//       });
//     } else {
//       return this.httpService.get<IUserModel>(UrlConstants.URL_API_USER);
//     }
//   }

  setUser(user: IUserModel): void {
    this.storageService.setData<IUserModel>(AppConstants.LOCAL_STORAGE_USER, user);
  }

  getUser(): IUserModel | null {
    const user = this.storageService.getData(AppConstants.LOCAL_STORAGE_USER);
    return (!user ? null : JSON.parse(user) as IUserModel);
  }

  clearUser(): void {
    this.storageService.removeData(AppConstants.LOCAL_STORAGE_USER);
  }


}
