import { inject, Injectable } from '@angular/core';

import Keycloak, { KeycloakProfile } from 'keycloak-js';

import { LoginUIPortImpl } from './login-domain';

// MODELS
import { IUserModel } from '@models/index';
import { AppConstants } from '@utils/index';

// PORTS
import { IUserUIPort, UserUIPort } from '@ports/index';


@Injectable({
  providedIn: 'root'
})
export class LoginKeycloakDomain extends LoginUIPortImpl {

  // INJECTABLES
  private readonly _userPort: IUserUIPort = inject(UserUIPort);
  private readonly _keycloak: Keycloak = inject(Keycloak);

  override user(): Promise<IUserModel> {
    return new Promise((resolve, reject) => {
      this._keycloak.loadUserProfile().then((value: KeycloakProfile) => {
        const user: IUserModel = {
          email: (value.email ? value.email : AppConstants.UNKNOWN),
          firstName: (value.firstName ? value.firstName : AppConstants.UNKNOWN),
          lastName: (value.lastName ? value.lastName : AppConstants.UNKNOWN),
          id: (value.id ? value.id : AppConstants.UNKNOWN),
          location: AppConstants.UNKNOWN,
          token: this._keycloak.token ? this._keycloak.token : AppConstants.UNKNOWN,
          userName: (value.username ? value.username : AppConstants.UNKNOWN),
          roles: this._keycloak.realmAccess?.roles ? this._keycloak.realmAccess?.roles : [AppConstants.UNKNOWN]
        };
        this._userPort.setUser(user)
        resolve(user);
      });
    });

  }

  override logout(): void {
    this._keycloak.logout({ redirectUri: location.origin }).then(() => {
      this._keycloak.clearToken();
    });
    
  }
}
