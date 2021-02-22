import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root',
})
export class ChangeLogService {
  apiName = 'Default';

  constructor(private http: HttpService) {}

  getAll(): Observable<any> {
    return this.http.get(`/api/app/change-log`, null).pipe((res: any) => {
      return res;
    });
  }

  insert(data: any): Observable<any> {
    return this.http.post(`/api/app/change-log`, data).pipe((res: any) => {
      return res;
    });
  }

  update(data: any): Observable<any> {
    return this.http.put(`/api/app/change-log`, data).pipe((res: any) => {
      return res;
    });
  }

  delete(id: any): Observable<any> {
    return this.http.delete(`/api/app/change-log/${id}`, null).pipe((res: any) => {
      return res;
    });
  }

  getByPackageId(id: number) {
    return this.http.get(`/api/app/change-log/${id}/by-package-id`, null).pipe((res: any) => {
      return res;
    });
  }

}
