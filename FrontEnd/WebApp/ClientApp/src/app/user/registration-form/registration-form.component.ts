import { Component, OnInit } from '@angular/core';

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

  registerUser({ user, valid }: { user: UserRegistration, valid: boolean }) {
    this.submitted = true;
    this.isRequesting = true;
    this.errors = '';
    if (valid) {
      this.userService.register(user)
        .subscribe(
          result => {
            if (result) {
              this.router.navigate(['/login'], { queryParams: { brandNew: true, email: user.email } });
            }
          },
          errors => this.errors = errors);
    }
  }

}
