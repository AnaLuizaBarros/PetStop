import { LoginService } from './../service/login.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { NgbModalModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LoginComponent } from './login.component';
import {
  AuthService,
  AuthServiceConfig,
  FacebookLoginProvider,
  GoogleLoginProvider,
  SocialLoginModule,
} from 'angular-6-social-login';
import { environment } from 'src/environments/environment';

// Configs
export function getAuthServiceConfigs() {
  const config = new AuthServiceConfig([
    {
      id: FacebookLoginProvider.PROVIDER_ID,
      provider: new FacebookLoginProvider(environment.fbAppId),
    },
    {
      id: GoogleLoginProvider.PROVIDER_ID,
      provider: new GoogleLoginProvider(environment.googleClientId),
    },
  ]);
  return config;
}
@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    NgbModule,
    NgbModalModule,
    // SocialLoginModule,
  ],
  exports: [LoginComponent],
  declarations: [LoginComponent],
  entryComponents: [LoginComponent],
  providers: [
    LoginService,
    /* {
      provide: AuthServiceConfig,
      useFactory: getAuthServiceConfigs,
    },*/
  ],
})
export class LoginModule {}
