import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule } from '@angular/forms';
import { SharedModule } from '../common/modules/shared.module';
import { UserService } from '../common/services/user.service';
import { EmailValidator } from '../common/utils/directives/emailvalidator.directive';

import { routing } from './user.routing';
import { RegistrationFormComponent } from './registration-form/registration-form.component';
import { LoginFormComponent } from './login-form/login-form.component';

@NgModule({
  imports: [
    CommonModule, FormsModule, routing, SharedModule
  ],
  declarations: [RegistrationFormComponent, EmailValidator, LoginFormComponent],
  providers: [UserService]
})
export class UserModule { }
