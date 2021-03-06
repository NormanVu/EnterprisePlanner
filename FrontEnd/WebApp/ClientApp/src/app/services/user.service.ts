import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserRegistration } from '../models/userregistration.interface';
import { ConfigService } from './config.service';
import { BaseService } from './base.service';

import { BehaviorSubject } from 'rxjs';

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
    this.baseUrl = configService.getApiEndpointAuthentication();
  }

  register(user: UserRegistration) {
    let email = user.email, password = user.password, firstname = user.firstName, lastname = user.lastName, location = user.location;
    let body = JSON.stringify({ email, password, firstname, lastname, location });
    let httpHeaders = new HttpHeaders().set('Content-Type', 'application/json');

    let options = {
      headers: httpHeaders
    }; 

    return this.http.post<UserRegistration>(this.baseUrl + "/users", body, options);
  }

  login(userName, password) {
    let httpHeaders = new HttpHeaders().set('Content-Type', 'application/json');

    let options = {
      headers: httpHeaders
    };
       
    let UserName = userName;
    let Password = password;
    let body = JSON.stringify({ UserName, Password });
    return this.http.post(this.baseUrl + '/auth/login', body, options);
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

