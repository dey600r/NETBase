import { inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { LoginUIPortImpl } from './login-domain';

// MODELS
import { IUserModel } from '@models/index';
import { UrlConstants } from '@utils/index';

// PORTS
import { ISecurityApiPort, IUserUIPort, SecurityApiPort, UserUIPort } from '@ports/index';

@Injectable({
  providedIn: 'root'
})
export class LoginJWTDomain extends LoginUIPortImpl {

  // INJECTABLES
  private readonly _router: Router = inject(Router);
  private readonly _userPort: IUserUIPort = inject(UserUIPort);
  private readonly _securityApi: ISecurityApiPort = inject(SecurityApiPort);

  override login(email: string, password: string): Promise<IUserModel> {
      return this._securityApi.login(email, password);
  }

  override user(): Promise<IUserModel> {
    return this._securityApi.getUser();
  }

  override validateToken(roles: string[]): boolean {
    let user: IUserModel | null = this._userPort.getUser();

    if(!user || !user.token) {
      this._router.navigateByUrl(UrlConstants.URL_LOGIN);
      return false;
    }
    
    return this.validateRoles(user.roles, roles);
  }

  override logout(): void {
    this._userPort.clearUser();
    this._router.navigateByUrl(UrlConstants.URL_LOGIN);
  }
}
