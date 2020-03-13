import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { UserRegistration } from '../../models/userregistration.interface';
import { UserService } from '../../services/user.service';
import { NgForm } from '@angular/forms';

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

  registerUser(fuser: NgForm) {
    this.submitted = true;
    this.isRequesting = true;
    this.errors = '';
    var user: UserRegistration = {
      email: fuser.controls['email'].value,
      password: fuser.controls['password'].value,
      firstName: fuser.controls['firstName'].value,
      lastName: fuser.controls['lastName'].value,
      location: fuser.controls['location'].value
    };
    var valid: boolean = fuser.valid;
    if (valid)
    {
      this.userService.register(user)
        .subscribe(
          result => {
            if (result) {
              this.router.navigate(['/login'], { queryParams: { brandNew: true, email: user.email } });
            }
          },
          errors => {
            var httpErrorResponse: HttpErrorResponse = errors;
            if (httpErrorResponse != null) {
              this.errors = httpErrorResponse.message;
            }
            else {
              this.errors = 'Some things go wrong!';
            }
          });
    }
  }
}
