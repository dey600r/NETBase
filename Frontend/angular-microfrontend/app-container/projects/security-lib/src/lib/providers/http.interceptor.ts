import {inject, Injectable} from '@angular/core';
import { Router } from '@angular/router';
import {HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpHeaders, HttpErrorResponse, HTTP_INTERCEPTORS} from '@angular/common/http';
import {Observable, catchError, throwError} from 'rxjs';

import { APP_CONFIG } from './app-config.provider';

// SERVICES
import { ISecurityService, MaterialService, SecurityAbstractService, UserService } from '@lib-services/index';

// UTILS
import { SecurityLibUrlConstants } from '@lib-utils/index';
import { AppConfig } from '@lib-models/index';

@Injectable()
export class APIInterceptor implements HttpInterceptor {

  private readonly urlNotSecurized: string[] = [
    SecurityLibUrlConstants.URL_API_LOGIN,
    SecurityLibUrlConstants.URL_SIGNUP
  ];

  private readonly _userService: UserService = inject(UserService);
  private readonly _materialService: MaterialService = inject(MaterialService);
  private readonly _router: Router = inject(Router);

  private readonly _appConfig: AppConfig = inject(APP_CONFIG);

  constructor() {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    let header: any = {
      'Content-Type': 'application/json'
    };
    if(!this.urlNotSecurized.some(x => req.url.endsWith(x))) {
      header['Authorization'] = `Bearer ${this._userService.getUser()?.token}`;
    }

    const apiReq = req.clone({ 
      headers: new HttpHeaders(header),
      url: `${this._appConfig.apiUrl}${req.url}`,
    });
    return next.handle(apiReq)
            .pipe(catchError((err: HttpErrorResponse, caught) => {
              switch(err.status) {
                case 401:
                case 403:
                  this._materialService.openSnackBar(err.statusText);
                  this._router.navigateByUrl(SecurityLibUrlConstants.URL_API_LOGIN);
                  break;
              }
              return throwError(() => err);
            }));
  }
}

export const ProviderInterceptorApp = [
  { provide: HTTP_INTERCEPTORS, useClass: APIInterceptor, multi: true }
];
