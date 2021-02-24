import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  apiName = 'Default';

  getUserLogged(): Observable<any> {
    return this.http.get(`/api/app/application-user/user-logged`, null).pipe((res: any) => {
      return res;
    });
  }


  constructor(private http: HttpService) {}
}
