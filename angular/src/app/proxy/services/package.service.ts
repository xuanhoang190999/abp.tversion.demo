import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root',
})
export class PackageService {
  apiName = 'Default';

  get(): Observable<any> {
    return this.http.get(`/api/app/package`, null).pipe((res: any) => {
      return res;
    });
  }

  insert(data: any): Observable<any> {
    return this.http.post(`/api/app/package`, data).pipe((res: any) => {
      return res;
    });
  }

  update(data: any, id: any): Observable<any> {
    return this.http.put(`/api/app/package/${id}`, data).pipe((res: any) => {
      return res;
    });
  }

  delete(id: any): Observable<any> {
    return this.http.delete(`/api/app/package/${id}`, null).pipe((res: any) => {
      return res;
    });
  }

  constructor(private http: HttpService) {}
}
