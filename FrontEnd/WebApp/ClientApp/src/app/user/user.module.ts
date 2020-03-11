import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RegistrationFormComponent } from './registration-form/registration-form.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { EmailValidator } from '../commons/utils/directives/emailvalidator.directive';
import { SpinnerComponent } from '../commons/utils/spinner/spinner.component';

/* services */
import { UserService } from '../services/user.service';
import { ConfigService } from '../services/config.service';

/* routers */
import { RoutingUser } from '../user/user.routing';


@NgModule({
  declarations: [
    RegistrationFormComponent,
    LoginFormComponent,
    EmailValidator
  ],

  imports: [
    CommonModule,
    FormsModule,
    RoutingUser
  ],
  providers: [ConfigService, UserService]
})
export class UserModule { }
