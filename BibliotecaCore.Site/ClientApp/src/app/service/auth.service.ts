import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { tap, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { ResponseAuth } from '../model/response-auth';
import { UserAuth } from '../model/user-auth';

const API_URL = 'https://localhost:44373/api/autentication/';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  securityObject: ResponseAuth = new ResponseAuth();

  constructor(private http: HttpClient) { }

  resetSecurityObject() {
    this.securityObject.token = '';
    this.securityObject.expiredDateTime = new Date;
    this.securityObject.isAuthenticated = false;
  }

  login(user: UserAuth) {
    this.resetSecurityObject();
    return this.http.post(`${API_URL}token`, user, httpOptions)
    .pipe(
      tap((resp: ResponseAuth) => {
        Object.assign(this.securityObject, resp);
        localStorage.setItem('bearerToken', this.securityObject.token);
      }),
      catchError(this.handleError)
    );
  }

  logout() {
    this.resetSecurityObject();
    localStorage.removeItem('bearerToken');
  }

  handleError(err: any) {
    return throwError(err.error);
  }
}
