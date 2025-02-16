import { inject, Injectable } from '@angular/core';

import { StorageService } from '@helpers/index';

import { AppConstants, UrlConstants } from '@utils/index';
import { IUserModel, ILoginModel, ISignupModel } from '@models/index';
import { Router } from '@angular/router';
import { ILoginUIPort, ISecurityApiPort } from '@ports/index';
import { SecurityService } from '@api/index';
// import { KeycloakService } from 'keycloak-angular';
// import { KeycloakProfile } from 'keycloak-js';
// import { environment } from '@environments/environment';
// import { MaterialService } from './material.service';

@Injectable({
  providedIn: 'root'
})
export class LoginDomain implements ILoginUIPort {

    // INJECTABLES
    private readonly storageService: StorageService = inject(StorageService);
    private readonly securityApi: ISecurityApiPort = inject(SecurityService);

    constructor() {
    }

    login(email: string, password: string): Promise<IUserModel> {
        return this.securityApi.login(email, password);
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

//   validateToken(roles: string[]): boolean {
//     let user: IUserModel | null = this.getUser();

//     if(!user || !user.token) {
//       this.router.navigateByUrl(UrlConstants.URL_LOGIN);
//       return false;
//     }
    
//     return this.validateRoles(user.roles, roles);
//   }

//   validateRoles(rolesToken: string[], rolesPage: string[]): boolean {
//     // Allow the user to to proceed if no additional roles are required to access the route.
//     if (!(rolesPage instanceof Array) || rolesPage.length === 0) {
//       return true;
//     }

//     const validated = rolesPage.some((role) => rolesToken.includes(role));
//     if(!validated) {
//       this.materialService.openSnackBar('Unauthorized!!!');
//     }
//     return validated;
//   }

//   logout(): void {
//     if(environment.keycloak.enable) {
//       this.keycloak.logout(location.origin).then(() => {
//         this.keycloak.clearToken();
//       });
//     } else {
//       this.clearUser();
//       this.router.navigateByUrl(UrlConstants.URL_LOGIN);
//     }
    
//   }
}
