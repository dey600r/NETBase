import { inject, Injectable } from '@angular/core';
import { HttpService } from './http.service';

// MODELS
import { ILoginModel, ISignupModel, IUserModel } from '@models/index';
import { UrlConstants } from '@utils/index';

// PORTS
import { SecurityApiPort } from '@ports/index';

@Injectable({
  providedIn: 'root'
})
export class SecurityService implements SecurityApiPort {

  private readonly httpService: HttpService = inject(HttpService);

  login(email: string, password: string): Promise<IUserModel> {
    return this.httpService.post<ILoginModel, IUserModel>(UrlConstants.URL_API_LOGIN, { email, password });
  }

  signup(firstName: string, lastName: string, location: string, userName: string, email: string, password: string): Promise<IUserModel> {
    return this.httpService.post<ISignupModel, IUserModel>(UrlConstants.URL_API_SIGNUP, 
      { firstName, lastName, location, userName, email, password });
  }

  getUser(): Promise<IUserModel> {
    return this.httpService.get<IUserModel>(UrlConstants.URL_API_USER);
  }
}
