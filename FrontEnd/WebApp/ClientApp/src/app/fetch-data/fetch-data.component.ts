import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public customers: Customer[];

  constructor(http: HttpClient, @Inject('API_BASE_URL') baseUrl: string) {
    http.get<Customer[]>(baseUrl + 'api/customer').subscribe(result => {
      this.customers = result;
    }, error => console.error(error));
  }
}

interface Customer {
  id: string;
  name: string;
  address: string;
  business: string;
}
