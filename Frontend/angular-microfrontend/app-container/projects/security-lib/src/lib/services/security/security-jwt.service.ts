import { Injectable } from '@angular/core';

// SERVICES
import { SecurityService } from './security.service';

// UTILS
import { SecurityLibUrlConstants } from '@lib-utils/index';
import { IUserModel, ILoginModel } from '@lib-models/index';

@Injectable({
  providedIn: 'root'
})
export class SecurityJWTService extends SecurityService {

  //#region LOGIN

  override login(email: string, password: string): Promise<IUserModel> {
    return this._httpService.post<ILoginModel, IUserModel>(SecurityLibUrlConstants.URL_API_LOGIN, { email, password });
  }

  override user(): Promise<IUserModel> {
    return this._httpService.get<IUserModel>(SecurityLibUrlConstants.URL_API_USER);
  }

  override validateToken(roles: string[]): boolean {
    let user: IUserModel | null = this._userService.getUser();

    if(!user || !user.token) {
      this._router.navigateByUrl(SecurityLibUrlConstants.URL_LOGIN);
      return false;
    }
    
    return this.validateRoles(user.roles, roles);
  }
  
  override logout(): void {
      this._userService.clearUser();
      this._router.navigateByUrl(SecurityLibUrlConstants.URL_LOGIN);
  }

  //#endregion LOGIN

}
