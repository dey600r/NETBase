import { inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';

// HELPERS
import { MaterialService } from '@helpers/index';

// MODELS
import { IUserModel } from '@models/index';
import { AppConstants, UrlConstants } from '@utils/index';
import { environment } from '@environments/environment';

// PORTS
import { ISecurityApiPort, IUserUIPort, ILoginUIPort, SecurityApiPort, UserUIPort } from '@ports/index';
// import { KeycloakService } from 'keycloak-angular';
// import { KeycloakProfile } from 'keycloak-js';
// import { environment } from '@environments/environment';
// import { MaterialService } from './material.service';

@Injectable({
  providedIn: 'root'
})
export class LoginDomain implements ILoginUIPort {

    // INJECTABLES
    private readonly router: Router = inject(Router);
    private readonly materialService: MaterialService = inject(MaterialService);
    private readonly _userPort: IUserUIPort = inject(UserUIPort);
    private readonly _securityApi: ISecurityApiPort = inject(SecurityApiPort);

    login(email: string, password: string): Promise<IUserModel> {
        return this._securityApi.login(email, password);
    }

  user(): Promise<IUserModel> {
    // if(environment.keycloak.enable) {
    //   return new Promise((resolve, reject) => {
    //     this.keycloak.getToken().then(token => {
    //       this.keycloak.loadUserProfile().then((value: KeycloakProfile) => {
    //         const user: IUserModel = {
    //           email: (value.email ? value.email : AppConstants.UNKNOWN),
    //           firstName: (value.firstName ? value.firstName : AppConstants.UNKNOWN),
    //           lastName: (value.lastName ? value.lastName : AppConstants.UNKNOWN),
    //           id: (value.id ? value.id : AppConstants.UNKNOWN),
    //           location: AppConstants.UNKNOWN,
    //           token: token,
    //           userName: (value.username ? value.username : AppConstants.UNKNOWN),
    //           roles: this.keycloak.getUserRoles()
    //         };
    //         this.setUser(user)
    //         resolve(user);
    //       });
    //     });
    //   });
    // } else {
      return this._securityApi.getUser();
    // }
  }

  validateToken(roles: string[]): boolean {
    let user: IUserModel | null = this._userPort.getUser();

    if(!user || !user.token) {
      this.router.navigateByUrl(UrlConstants.URL_LOGIN);
      return false;
    }
    
    return this.validateRoles(user.roles, roles);
  }

  validateRoles(rolesToken: string[], rolesPage: string[]): boolean {
    // Allow the user to to proceed if no additional roles are required to access the route.
    if (!(rolesPage instanceof Array) || rolesPage.length === 0) {
      return true;
    }

    const validated = rolesPage.some((role) => rolesToken.includes(role));
    if(!validated) {
      this.materialService.openSnackBar('Unauthorized!!!');
    }
    return validated;
  }

  logout(): void {
    if(environment.keycloak.enable) {
      // this.keycloak.logout(location.origin).then(() => {
      //   this.keycloak.clearToken();
      // });
    } else {
      this._userPort.clearUser();
      this.router.navigateByUrl(UrlConstants.URL_LOGIN);
    }
    
  }
}
