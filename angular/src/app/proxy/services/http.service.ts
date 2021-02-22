import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import { Observable, EMPTY, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class HttpService {
  apiName = 'Default';

  constructor(private restService: RestService) {}

  public get(url: string, params?: any): Observable<any> {
    return this.restService.request({
      method: 'GET',
      url: url,
      params: params
    },
    { apiName: this.apiName })
    .pipe(
      catchError(error => {
        if (error.status == 401) {
            this.catchAuthError(error);
            return EMPTY;
        } else {
            return throwError(error);
        }
      })
    );
  }

  public post(url: string, body: any, options?: any): Observable<any> {
    return this.restService.request({
      method: 'POST',
      url: url,
      body: body,
    },
    { apiName: this.apiName })
    .pipe(
      catchError(error => {
        if (error.status == 401) {
            this.catchAuthError(error);
            return EMPTY;
        } else {
            return throwError(error);
        }
      })
    );
  }

  public put(url: string, body: any, options?: any): Observable<any> {
    return this.restService.request({
      method: 'PUT',
      url: url,
      body: body
    },
    { apiName: this.apiName })
    .pipe(
      catchError(error => {
        if (error.status == 401) {
            this.catchAuthError(error);
            return EMPTY;
        } else {
            return throwError(error);
        }
      })
    );
  }

  public delete(url: string, options?: any): Observable<any> {
    return this.restService.request({
      method: 'DELETE',
      url: url,
    },
    { apiName: this.apiName })
    .pipe(
      catchError(error => {
        if (error.status == 401) {
            this.catchAuthError(error);
            return EMPTY;
        } else {
            return throwError(error);
        }
      })
    );
  }

  private catchAuthError(self: HttpService) {
    return (res: Response) => {
        console.log(res);
        if (res.status === 401 || res.status === 403) {
            console.log(res);
        }

        return Observable.throw(res);
    };
}
}
