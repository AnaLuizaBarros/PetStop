import { CadastroModule } from './cadastro/cadastro.module';
import { HomeModule } from './home/home.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [AppComponent, LoginComponent],
  imports: [BrowserModule, AppRoutingModule, HomeModule, CadastroModule, ReactiveFormsModule],
  providers: [],
  bootstrap: [AppComponent],
  exports: [ReactiveFormsModule]
})
export class AppModule {}
