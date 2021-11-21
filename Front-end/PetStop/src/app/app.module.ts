import { CadastroModule } from './cadastro/cadastro.module';
import { HomeModule } from './home/home.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LoginModule } from './login/login.module';
import { SideBarModule } from './pages/side-bar/side-bar.module';
import { AnimalService } from './service/animal.service';
import { EspecieService } from './service/especie.service';
import { AlertModule } from '@full-fledged/alerts';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HomeModule,
    CadastroModule,
    LoginModule,
    SideBarModule,
    NgbModule,
    HttpClientModule,
    AlertModule.forRoot({ maxMessages: 5, timeout: 5000, positionX: 'right' }),
  ],
  providers: [AnimalService, EspecieService],
  bootstrap: [AppComponent],
})
export class AppModule {}
