import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserRegistration } from '../models/userregistration.interface';
import { ConfigService } from '../utils/config.service';
import { BaseService } from './base.service';

import { Observable, BehaviorSubject } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

@Injectable()

export class UserService extends BaseService {

  baseUrl: string = '';

  // Observable navItem source
  private _authNavStatusSource = new BehaviorSubject<boolean>(false);
  // Observable navItem stream
  authNavStatus$ = this._authNavStatusSource.asObservable();

  private loggedIn = false;

  constructor(private http: HttpClient, private configService: ConfigService) {
    super();
    this.loggedIn = !!localStorage.getItem('auth_token');
    // ?? not sure if this the best way to broadcast the status but seems to resolve issue on page refresh where auth status is lost in
    // header component resulting in authenticated user nav links disappearing despite the fact user is still logged in
    this._authNavStatusSource.next(this.loggedIn);
    this.baseUrl = configService.getApiURI();
  }

  register(user: UserRegistration): Observable<UserRegistration> {
    let email = user.email, password = user.password, firstname = user.firstName, lastname = user.lastName, location = user.location;
    let body = JSON.stringify({ email, password,firstname, lastname, location });
    let httpHeaders = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Cache-Control', 'no-cache');
    let options = {
      headers: httpHeaders
    }; 

    return this.http.post<UserRegistration>(this.baseUrl + "/users", body, options);
  }

  login(userName, password) {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');

    return this.http.post(
        this.baseUrl + '/auth/login',
        JSON.stringify({ userName, password }), { headers }
      );
  }

  logout() {
    localStorage.removeItem('auth_token');
    this.loggedIn = false;
    this._authNavStatusSource.next(false);
  }

  isLoggedIn() {
    return this.loggedIn;
  }
}

