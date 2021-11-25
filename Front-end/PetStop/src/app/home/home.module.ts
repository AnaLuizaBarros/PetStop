import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { CadastroDoadorModule } from '../cadastroDoador/cadastro.doador.module';
import { CadastroAdotanteModule } from '../cadastroAdotante/cadastro.adotante.module';

@NgModule({
  imports: [CommonModule, SharedModule, HomeRoutingModule, MatDatepickerModule, CadastroDoadorModule, CadastroAdotanteModule],
  declarations: [HomeComponent],
  exports: [HomeComponent],
  providers: [],
})
export class HomeModule {
  constructor() {}
}
