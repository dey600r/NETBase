import {Injectable} from '@angular/core';
import {HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpHeaders, HttpErrorResponse} from '@angular/common/http';
import {Observable, catchError, throwError} from 'rxjs';

import { environment } from '@environments/environment';
import { UrlConstants } from '@utils/index';
import { MaterialService, SecurityService } from '@services/index';
import { Router } from '@angular/router';

@Injectable()
export class APIInterceptor implements HttpInterceptor {

  private urlSecurized: string[] = [
    UrlConstants.URL_API_USER,
    UrlConstants.URL_API_SETTING_GET_ALL
  ];

  constructor(private securityService: SecurityService,
    private materialService: MaterialService,
    private router: Router) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    let header: any = {
      'Content-Type': 'application/json'
    };
    if(this.urlSecurized.some(x => req.url.endsWith(x))) {
      header['Authorization'] = `Bearer ${this.securityService.getUser()?.token}`;
    }

    const apiReq = req.clone({ 
      headers: new HttpHeaders(header),
      url: `${environment.apiUrl}${req.url}`,
    });
    return next.handle(apiReq)
            .pipe(catchError((err: HttpErrorResponse, caught) => {
              switch(err.status) {
                case 401:
                  this.materialService.openSnackBar(err.statusText);
                  this.router.navigateByUrl(UrlConstants.URL_API_LOGIN);
                  break;
              }
              return throwError(() => err);
            }));
  }
}