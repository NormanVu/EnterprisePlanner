import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { RegistrationFormComponent } from './user/registration-form/registration-form.component';
import { LoginFormComponent } from './user/login-form/login-form.component';
import { GridModule } from '@progress/kendo-angular-grid';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';

/* modules */
import { UserModule } from './user/user.module';
import { ConfigService } from './common/utils/config.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'fetch-data', component: FetchDataComponent }
    ]),
    GridModule,
    BrowserAnimationsModule
  ],
  providers: [
    { provide: 'API_BASE_URL', useFactory: getBaseAPIGetwayUrl, deps: [] }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  static baseApiGetwayUrl = "http://localhost:5000/";
}

export function getBaseAPIGetwayUrl() {
  return AppModule.baseApiGetwayUrl;
}
