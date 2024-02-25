import { Injectable } from '@angular/core';

import { HttpService } from './http.service';
import { StorageService } from './storage.service';

import { AppConstants, UrlConstants } from '@utils/index';
import { IUserModel, ILoginModel, ISignupModel } from '@models/index';
import { Router } from '@angular/router';
import { KeycloakService } from 'keycloak-angular';
import { KeycloakProfile } from 'keycloak-js';
import { map } from 'rxjs';
import { environment } from '@environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SecurityService {

  constructor(private httpService: HttpService,
    private storageService: StorageService,
    private keycloak: KeycloakService,
    private router: Router) { }

  login(email: string, password: string): Promise<IUserModel> {
    return this.httpService.post<ILoginModel, IUserModel>(UrlConstants.URL_API_LOGIN, { email, password });
  }

  signup(firstName: string, lastName: string, location: string, userName: string, email: string, password: string): Promise<IUserModel> {
    return this.httpService.post<ISignupModel, IUserModel>(UrlConstants.URL_API_SIGNUP, 
      { firstName, lastName, location, userName, email, password });
  }

  user(): Promise<IUserModel> {
    if(environment.keycloak.enable) {
      return new Promise((resolve, reject) => {
        this.keycloak.getToken().then(token => {
          this.keycloak.loadUserProfile().then((value: KeycloakProfile) => {
            const user: IUserModel = {
              email: (value.email ? value.email : AppConstants.UNKNOWN),
              firstName: (value.firstName ? value.firstName : AppConstants.UNKNOWN),
              lastName: (value.lastName ? value.lastName : AppConstants.UNKNOWN),
              id: (value.id ? value.id : AppConstants.UNKNOWN),
              location: AppConstants.UNKNOWN,
              token: token,
              userName: (value.username ? value.username : AppConstants.UNKNOWN),
              roles: this.keycloak.getUserRoles()
            };
            this.setUser(user)
            resolve(user);
          });
        });
      });
    } else {
      return this.httpService.get<IUserModel>(UrlConstants.URL_API_USER);
    }
  }

  setUser(user: IUserModel) {
    this.storageService.setData<IUserModel>(AppConstants.LOCAL_STORAGE_USER, user);
  }

  getUser(): IUserModel | null {
    const user = this.storageService.getData(AppConstants.LOCAL_STORAGE_USER);
    return (!user ? null : JSON.parse(user) as IUserModel);
  }

  clearUser(): void {
    this.storageService.removeData(AppConstants.LOCAL_STORAGE_USER);
  }

  validateToken(): boolean {
    let user: IUserModel | null = this.getUser();

    if(!user || !user.token) {
      this.router.navigateByUrl(UrlConstants.URL_LOGIN);
      return false;
    }
    
    return true;
  }

  logout(): void {
    if(environment.keycloak.enable) {
      this.keycloak.logout(location.origin).then(() => {
        this.keycloak.clearToken();
      });
    } else {
      this.clearUser();
      this.router.navigateByUrl(UrlConstants.URL_API_LOGIN);
    }
    
  }
}
