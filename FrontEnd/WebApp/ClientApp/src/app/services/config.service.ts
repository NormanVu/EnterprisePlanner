import { Injectable } from '@angular/core';

@Injectable()
export class ConfigService {

  _apiAuthenticationURI: string;

  constructor() {
    this._apiAuthenticationURI = 'http://localhost:5002/api';
  }

  getApiEndpointAuthentication() {
    return this._apiAuthenticationURI;
  }
}
