import { inject, Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { ILoginModel, ISignupModel, IUserModel } from '@models/index';
import { UrlConstants } from '@utils/index';
import { ISecurityApiPort } from '@ports/index';

@Injectable({
  providedIn: 'root'
})
export class SecurityService implements ISecurityApiPort {

  private readonly httpService: HttpService = inject(HttpService);
  
  constructor() { 
  }

  login(email: string, password: string): Promise<IUserModel> {
    return this.httpService.post<ILoginModel, IUserModel>(UrlConstants.URL_API_LOGIN, { email, password });
  }

  signup(firstName: string, lastName: string, location: string, userName: string, email: string, password: string): Promise<IUserModel> {
    return this.httpService.post<ISignupModel, IUserModel>(UrlConstants.URL_API_SIGNUP, 
      { firstName, lastName, location, userName, email, password });
  }
}
