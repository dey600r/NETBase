import {inject, Injectable} from '@angular/core';
import { Router } from '@angular/router';
import {HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpHeaders, HttpErrorResponse, HTTP_INTERCEPTORS} from '@angular/common/http';
import {Observable, catchError, throwError} from 'rxjs';

import { UrlConstants } from '@utils/index';
import { IUserUIPort } from '@app/domain/ports/index';
import { MaterialService } from '@helpers/index';
import { environment } from '@environments/environment';
import { UserDomain } from '@app/domain/core';
import { AppConfig } from '@models/index';
import { APP_CONFIG } from './app-config.provider';

@Injectable()
export class APIInterceptor implements HttpInterceptor {

  private readonly urlNotSecurized: string[] = [
    UrlConstants.URL_API_LOGIN,
    UrlConstants.URL_SIGNUP
  ];

  private readonly userDomain: IUserUIPort = inject(UserDomain);
  private readonly materialService: MaterialService = inject(MaterialService);
  private readonly router: Router = inject(Router);
  private readonly _appConfig: AppConfig = inject(APP_CONFIG);

  constructor() {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    let header: any = {
      'Content-Type': 'application/json'
    };
    if(!this.urlNotSecurized.some(x => req.url.endsWith(x))) {
      header['Authorization'] = `Bearer ${this.userDomain.getUser()?.token}`;
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
                  this.materialService.openSnackBar(err.statusText);
                  this.router.navigateByUrl(UrlConstants.URL_API_LOGIN);
                  break;
              }
              return throwError(() => err);
            }));
  }
}

export const ProviderInterceptorApp = [
  { provide: HTTP_INTERCEPTORS, useClass: APIInterceptor, multi: true }
];
