import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom, catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  constructor(private http: HttpClient) { }


  get<T>(url: string, params: string = ''): Promise<T> {
    return firstValueFrom(this.http.get<T>(`${url}`)
      .pipe(
        catchError((err, caught) => {
          const messageError: string = (err.error && err.error.message ? err.error.message : 'Global error');
          this.handleError('GET', messageError, params);
          return throwError(() => new Error(messageError));
        })
      ));
  }

  post<T, R>(url: string, body: T): Promise<R> {
    return firstValueFrom(this.http.post<R>(`${url}`, body)
      .pipe(
        catchError((err, caught) => {
          const messageError: string = (err.error && err.error.message ? err.error.message : 'Global error');
          this.handleError('POST', messageError, body);
          return throwError(() => new Error(messageError));
        })
      ));
  }

  private handleError<T>(title: string, err: string, body: T) {
    console.error(`${title}: ${err} - ${body}`);
  }
}
