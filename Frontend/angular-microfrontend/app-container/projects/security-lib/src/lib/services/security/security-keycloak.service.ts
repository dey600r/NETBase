import { inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';

// SERVICES
// import { HttpService } from '../http.service';
// import { StorageService } from '../storage.service';
// import { MaterialService } from '../material.service';
import { SecurityService } from './security.service';

// UTILS
// import { SecurityLibUrlConstants } from '@lib-utils/index';
import { IUserModel, ILoginModel } from '../../models/index';

@Injectable({
  providedIn: 'root'
})
export class SecurityKeycloakService extends SecurityService {

  //#region LOGIN

  override user(): Promise<IUserModel> {
    return new Promise((resolve, reject) => {
    // this.keycloak.getToken().then(token => {
    //   this.keycloak.loadUserProfile().then((value: KeycloakProfile) => {
    //     const user: IUserModel = {
    //       email: (value.email ? value.email : AppConstants.UNKNOWN),
    //       firstName: (value.firstName ? value.firstName : AppConstants.UNKNOWN),
    //       lastName: (value.lastName ? value.lastName : AppConstants.UNKNOWN),
    //       id: (value.id ? value.id : AppConstants.UNKNOWN),
    //       location: AppConstants.UNKNOWN,
    //       token: token,
    //       userName: (value.username ? value.username : AppConstants.UNKNOWN),
    //       roles: this.keycloak.getUserRoles()
    //     };
    //     this.setUser(user)
    //     resolve(user);
    //   });
    // });
    });
  }

  override logout(): void {
    // this.keycloak.logout(location.origin).then(() => {
    //   this.keycloak.clearToken();
    // });
  }

  //#endregion LOGIN

}
