import { Injectable } from '@angular/core';

import { HttpService } from './http.service';
import { StorageService } from './storage.service';

import { AppConstants, UrlConstants } from '@utils/index';
import { IUserModel, ILoginModel, ISignupModel } from '@models/index';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class SecurityService {

  constructor(private httpService: HttpService,
    private storageService: StorageService,
    private router: Router) { }

  login(email: string, password: string): Promise<IUserModel> {
    return this.httpService.post<ILoginModel, IUserModel>(UrlConstants.URL_API_LOGIN, { email, password });
  }

  signup(firstName: string, lastName: string, location: string, userName: string, email: string, password: string): Promise<IUserModel> {
    return this.httpService.post<ISignupModel, IUserModel>(UrlConstants.URL_API_SIGNUP, 
      { firstName, lastName, location, userName, email, password });
  }

  user(): Promise<IUserModel> {
    return this.httpService.get<IUserModel>(UrlConstants.URL_API_USER);
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
    this.clearUser();
    this.router.navigateByUrl(UrlConstants.URL_API_LOGIN);
  }
}
