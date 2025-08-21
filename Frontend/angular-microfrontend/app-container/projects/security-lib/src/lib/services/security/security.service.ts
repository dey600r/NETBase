import { inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';

// SERVICES
import { HttpService } from '../http.service';
import { MaterialService } from '../material.service';
import { SecurityAbstractService } from './security.interface';
import { UserService } from './user.service';

// UTILS
import { IUserModel, ISignupModel } from '../../models/index';
import { SecurityLibUrlConstants } from '../../utils/index';

@Injectable({
  providedIn: 'root'
})
export class SecurityService extends SecurityAbstractService {

  protected readonly _httpService: HttpService = inject(HttpService);
  protected readonly _materialService: MaterialService = inject(MaterialService);
  protected readonly _userService: UserService = inject(UserService);
  protected readonly _router: Router = inject(Router);

  //#region LOGIN

  override login(email: string, password: string): Promise<IUserModel> {
    throw new Error("ONLY FOR JWT");
  }

  override validateToken(roles: string[]): boolean {
   throw new Error("ONLY FOR JWT");
  }

  override user(): Promise<IUserModel> {
    throw new Error("ONLY FOR JWT & KEYCLOAK");
  }

  override logout(): void {
    throw new Error("ONLY FOR JWT && KEYCLOAK");
  }

  validateRoles(rolesToken: string[], rolesPage: string[]): boolean {
    // Allow the user to to proceed if no additional roles are required to access the route.
    if (!(rolesPage instanceof Array) || rolesPage.length === 0) {
      return true;
    }

    const validated = rolesPage.some((role) => rolesToken.includes(role));
    if(!validated) {
      this._materialService.openSnackBar('Unauthorized!!!');
    }
    return validated;
  }

  //#endregion LOGIN

  //#region SIGINUP
  signup(firstName: string, lastName: string, location: string, userName: string, email: string, password: string): Promise<IUserModel> {
    return this._httpService.post<ISignupModel, IUserModel>(SecurityLibUrlConstants.URL_API_SIGNUP, 
      { firstName, lastName, location, userName, email, password });
  }

  //#endregion SIGINUP
}
