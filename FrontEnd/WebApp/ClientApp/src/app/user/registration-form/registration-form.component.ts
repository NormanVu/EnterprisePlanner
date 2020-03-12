import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { UserRegistration } from '../../models/userregistration.interface';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent implements OnInit {

  errors: string;
  isRequesting: boolean;
  submitted: boolean = false;

  constructor(private userService: UserService, private router: Router) {

  }

  ngOnInit() {

  }

  registerUser(value: UserRegistration, valid: boolean) {
    this.submitted = true;
    this.isRequesting = true;
    this.errors = '';
    if (valid) {
      this.userService.register(value)
        .subscribe(
          result => {
            if (result) {
              this.router.navigate(['/login'], { queryParams: { brandNew: true, email: value.email } });
            }
          },
        errors => {
          var httpErrorResponse: HttpErrorResponse = errors;
          if (httpErrorResponse != null) {
            this.errors = httpErrorResponse.message;
          }
          else
          {
            this.errors = 'Some things go wrong!';
          }
        });
    }
  }

}
