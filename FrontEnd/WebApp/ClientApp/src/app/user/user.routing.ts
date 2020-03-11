import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';

import { RegistrationFormComponent } from '../user/registration-form/registration-form.component';
import { LoginFormComponent } from '../user/login-form/login-form.component';

export const RoutingUser: ModuleWithProviders = RouterModule.forChild([
  { path: 'register', component: RegistrationFormComponent },
  { path: 'login', component: LoginFormComponent }
]);

