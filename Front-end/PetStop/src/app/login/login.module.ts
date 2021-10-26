import { LoginService } from './../service/login.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LoginComponent } from './login.component';

@NgModule({
  imports: [CommonModule, ReactiveFormsModule, NgbModule],
  declarations: [LoginComponent],
  providers: [LoginService],
})
export class LoginModule {}
