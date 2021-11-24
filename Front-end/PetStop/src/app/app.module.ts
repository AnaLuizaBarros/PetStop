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
import { MatDatepickerModule } from '@angular/material/datepicker';
import { CadastroService } from './service/cadastro.service';
import { CadastroDoadorModule } from './cadastroDoador/cadastro.doador.module';
import { CadastroAdotanteModule } from './cadastroAdotante/cadastro.adotante.module';
@NgModule({
  declarations: [AppComponent],
  imports: [
    MatDatepickerModule,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HomeModule,
    CadastroDoadorModule,
    CadastroAdotanteModule,
    LoginModule,
    SideBarModule,
    NgbModule,
    HttpClientModule,
    AlertModule.forRoot({ maxMessages: 5, timeout: 5000, positionX: 'right' }),
  ],
  providers: [AnimalService, EspecieService, CadastroService],
  bootstrap: [AppComponent],
})
export class AppModule {}
